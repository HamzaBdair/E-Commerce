using Microsoft.EntityFrameworkCore;
using E_Commerce.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Core.Interfaces;
using Infrastructure.Data;
using E_Commerce.Helper;
using E_Commerce.Middleware;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Errors;
using Microsoft.OpenApi.Models;
using E_Commerce.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocummentation();
builder.Services.AddAutoMapper(typeof(MappingProfiles));




var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services=scope.ServiceProvider;
    var loggerFactory=services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);
    }
    catch(Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An Error accurd during migration");
    }
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();

app.UseSwaggerDocumentation();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
