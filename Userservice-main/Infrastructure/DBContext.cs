using Microsoft.EntityFrameworkCore;
using WCFOnionService.Domain;

namespace WCFOnionService.Infrastructure
{
    public class DBContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual MySQL connection string
            optionsBuilder.UseMySQL("Server=localhost;Database=WCFDb;User=root;Password=password;");
        }
    }
}