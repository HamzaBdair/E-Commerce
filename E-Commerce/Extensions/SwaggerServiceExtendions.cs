using Microsoft.OpenApi.Models;

namespace E_Commerce.Extensions
{
    public static class SwaggerServiceExtendions
    {
        public static IServiceCollection AddSwaggerDocummentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c
.SwaggerDoc("v1", new OpenApiInfo { Title = "Skinet Api", Version = "v1" }));
            return services;    
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkiNet Api v1");
            });
            return app;
        }
    }
}
