using Microsoft.EntityFrameworkCore;
using StoreAPI.Models;

namespace StoreAPI.Data
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options){}

        public DbSet<Product> Products { get; set; }
    }
}