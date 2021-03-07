using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Entities;

namespace PetCare.Persistence.Data.Maps
{
    public class OwnerMap : IEntityTypeConfiguration<OwnerEntity>
    {
        public void Configure(EntityTypeBuilder<OwnerEntity> builder)
        {
            builder.ToTable("Owners"); // É o Padrão
            builder.HasKey(owner => owner.Id);

            builder.Property(owner => owner.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(owner => owner.LastName).IsRequired().HasMaxLength(50);
            builder.Property(owner => owner.Email).IsRequired();

            builder.HasIndex(owner => owner.Email).IsUnique();




        }
    }
}

