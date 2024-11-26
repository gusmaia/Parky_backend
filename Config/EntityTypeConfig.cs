using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parky_backend.Models;

namespace Parky_backend.Config;
public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.Type)
            .HasColumnType("CHAR(1)");

        builder.Property(x => x.CPF)
            .HasColumnType("VARCHAR(11)");

        builder.HasIndex(x => x.CPF)
            .IsUnique();

        builder.Property(x => x.CNPJ)
            .HasColumnType("VARCHAR(14)");

        builder.HasIndex(x => x.CNPJ)
            .IsUnique();

        builder.Property(x => x.Phone)
            .HasColumnType("VARCHAR(11)");

        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.CreatedAt)
            .HasColumnType("TIMESTAMP");
        
        builder.HasMany(x => x.Vehicle)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ParkingRegistry)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class VehicleTypeConfig : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.IsActive)
            .HasColumnType("CHAR(1)");
        
        builder.HasMany(x => x.Vehicle)
            .WithOne(x => x.VehicleType)
            .HasForeignKey(x => x.VehicleTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Fee)
            .WithOne(x => x.VehicleType)
            .HasForeignKey(x => x.VehicleTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ParkingSpace)
            .WithOne(x => x.VehicleType)
            .HasForeignKey(x => x.VehicleTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LicensePlate)
            .HasColumnType("VARCHAR(7)");

        builder.HasIndex(x => x.LicensePlate)
            .IsUnique();

        builder.Property(x => x.Model)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.Color)
            .HasColumnType("VARCHAR(20)");
        
        builder.HasMany(x => x.ParkingRegistry)
            .WithOne(x => x.Vehicle)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class FeeConfig : IEntityTypeConfiguration<Fee>
{
    public void Configure(EntityTypeBuilder<Fee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.HourlyRate)
            .HasColumnType("DECIMAL(18,2)");

        builder.HasMany(x => x.ParkingRegistry)
            .WithOne(x => x.Fee)
            .HasForeignKey(x => x.FeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class ParkingSpaceConfig : IEntityTypeConfiguration<ParkingSpace>
{
    public void Configure(EntityTypeBuilder<ParkingSpace> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Location)
            .HasColumnType("VARCHAR(45)");

        builder.Property(x => x.Available)
            .HasColumnType("CHAR(1)");

        builder.HasMany(x => x.ParkingRegistry)
            .WithOne(x => x.ParkingSpace)
            .HasForeignKey(x => x.ParkingSpaceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class ParkingRegistryConfig : IEntityTypeConfiguration<ParkingRegistry>
{
    public void Configure(EntityTypeBuilder<ParkingRegistry> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntryDateTime)
            .HasColumnType("TIMESTAMP");

        builder.Property(x => x.ExitDateTime)
            .HasColumnType("TIMESTAMP");
        
        builder.Property(x => x.TotalValue)
            .HasColumnType("DECIMAL(18,2)");
    }
}