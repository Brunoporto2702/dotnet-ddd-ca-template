using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialCommerce.Application.Commom.Interfaces.Persistence;
using SocialCommerce.Application.Common.Interfaces;
using SocialCommerce.Infraestructure.Authentication;
using SocialCommerce.Infraestructure.Persistence;

namespace SocialCommerce.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}