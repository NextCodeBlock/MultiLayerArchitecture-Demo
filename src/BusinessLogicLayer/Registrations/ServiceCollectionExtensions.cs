using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiLayerArchitectureDemo.DataAccessLayer.Registrations;
using System.Reflection;
using MediatR;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Registrations;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddDataAccessLayer();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}