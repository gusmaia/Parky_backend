using Microsoft.EntityFrameworkCore;
using Parky_backend.Models;
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
            modelBuilder.Entity<Fee>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ParkingRegistry>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ParkingSpace>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Vehicle>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<VehicleType>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
