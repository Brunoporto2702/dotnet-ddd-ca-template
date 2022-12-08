

using Mapster;
using SocialCommerce.Application.Authentication.Commands;
using SocialCommerce.Application.Authentication.Commom;
using SocialCommerce.Contracts.Authentication;

namespace SocialCommerce.Application.Common.Mapping.Authentication;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        // config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthResult, AuthenticationResponse>();
    }
}