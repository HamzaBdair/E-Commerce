using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products{ get; set; }
    }
}
