
using CareerOps.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CareerOps.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCareerOpsInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("CareerOps")
            ?? throw new InvalidOperationException(
                "Connection string 'CareerOps' was not configured.");

        services.AddDbContext<CareerOpsDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
