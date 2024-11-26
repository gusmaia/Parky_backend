using Microsoft.EntityFrameworkCore;
using Parky_backend.Models;
using Parky_backend.Config;
// dotnet ef migrations add MigrationName --output-dir Data/Migrations


namespace Parky_backend.Data
{
    public class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Client>? Client { get; set; }
        public DbSet<Fee>? Fee { get; set; }
        public DbSet<ParkingRegistry>? ParkingRegistry { get; set; }
        public DbSet<ParkingSpace>? ParkingSpace { get; set; }
        public DbSet<Vehicle>? Vehicle { get; set; }
        public DbSet<VehicleType>? VehicleType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseFirebird("Default");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfig());
            modelBuilder.ApplyConfiguration(new FeeConfig());
            modelBuilder.ApplyConfiguration(new ParkingSpaceConfig());
            modelBuilder.ApplyConfiguration(new ParkingRegistryConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
