using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;
using MultiLayerArchitectureDemo.DataAccessLayer.Context;
using MultiLayerArchitectureDemo.DataAccessLayer.Seeder;
using MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Registrations;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccessLayer(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("MultiLayerArchitectureDemoDatabase");
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
 
        services.SeedData();
    }

    private static void SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var initializers = serviceProvider.GetServices<IDatabaseSeeder>();

        foreach (var initializer in initializers)
        {
            initializer.Initialize();
        }
    }
}