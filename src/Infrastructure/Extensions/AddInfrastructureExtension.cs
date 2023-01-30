using Microsoft.EntityFrameworkCore;
using AuthService.Infrastructure;
using AuthService.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddInfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ApplicationException("Connection string is not configured");
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        return services;
    }
}