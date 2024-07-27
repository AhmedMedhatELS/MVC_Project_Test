using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", true, true).
                Build().
                GetConnectionString("DefaultConnection");


            optionsBuilder.UseSqlServer(builder);
        }
    }
}
