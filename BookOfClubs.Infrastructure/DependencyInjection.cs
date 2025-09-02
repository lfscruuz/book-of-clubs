using BookOfClubs.Application.Common.Interfaces.Authentication;
using BookOfClubs.Application.Common.Interfaces.Services;
using BookOfClubs.Infrastructure.Authentication;
using BookOfClubs.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace BookOfClubs.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.Sectionname));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
        return services;
    }
}
