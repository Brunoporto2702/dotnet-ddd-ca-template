using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialCommerce.Application.Authentication.Commands;

namespace SocialCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddAutoMapper(typeof(MappingProfile));
        // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<RegisterCommandHandler>();
        return services;
    }
}