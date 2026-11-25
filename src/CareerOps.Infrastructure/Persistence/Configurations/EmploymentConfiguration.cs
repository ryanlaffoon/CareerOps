
using CareerOps.Modules.ProfessionalProfile.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOps.Infrastructure.Persistence.Configurations;

public sealed class EmploymentConfiguration
    : IEntityTypeConfiguration<Employment>
{
    public void Configure(EntityTypeBuilder<Employment> builder)
    {
        builder.ToTable("Employments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.JobTitle)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate);

        builder.Property(x => x.Description)
            .HasMaxLength(4000);

        builder.Property(x => x.IsCurrent)
            .IsRequired();

        builder.Property(x => x.CreatedAtUtc)
            .IsRequired();

        builder.HasIndex(x => x.CompanyName);

        builder.HasIndex(x => x.StartDate);
    }
}
