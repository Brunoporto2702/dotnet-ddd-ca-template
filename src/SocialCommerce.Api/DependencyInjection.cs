// using SocialCommerce.Api.Common.Errors;
using SocialCommerce.Api.Common.Mapping;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using SocialCommerce.Api.Common.Errors;

namespace SocialCommerce.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, SocialCommerceApiErrorsFactory>();
        services.AddMappings();

        //swagger 
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}