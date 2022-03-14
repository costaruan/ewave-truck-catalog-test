using Microsoft.EntityFrameworkCore;
using TruckCatalog.Models.Models;

namespace TruckCatalog.Data.Contexts
{
    public class TruckCatalogContext : DbContext
    {
        public TruckCatalogContext(DbContextOptions<TruckCatalogContext> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>()
                .HasKey(truck => truck.Id);
        }
    }
}
