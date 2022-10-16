using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class DemoContext: DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
