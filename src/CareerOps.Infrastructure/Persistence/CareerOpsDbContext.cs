
using CareerOps.Modules.ProfessionalProfile.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerOps.Infrastructure.Persistence;

public sealed class CareerOpsDbContext(
    DbContextOptions<CareerOpsDbContext> options) : DbContext(options)
{
    public DbSet<Employment> Employments => Set<Employment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CareerOpsDbContext).Assembly);
    }
}
