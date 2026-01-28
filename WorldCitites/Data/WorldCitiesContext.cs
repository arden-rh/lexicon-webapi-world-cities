using Microsoft.EntityFrameworkCore;
using WorldCitites.Models;
namespace WorldCitites.Data
{
    public class WorldCitiesContext : DbContext
    {
        public WorldCitiesContext(DbContextOptions<WorldCitiesContext> options)
            : base(options)
        {
        }

        public DbSet<WorldCity> WorldCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldCity>().HasData(
                new WorldCity { CityId = 1, City = "New York", Country = "USA", Population = 8419600 },
                new WorldCity { CityId = 2, City = "Tokyo", Country = "Japan", Population = 13929286 },
                new WorldCity { CityId = 3, City = "London", Country = "UK", Population = 8982000 }
            );
        }
    }
}