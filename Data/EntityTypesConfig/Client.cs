using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parky_backend.Models;

namespace Parky_backend.Data.EntityTypesConfig;
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
        
        builder.HasMany("Vehicle");
    }
}
