using SocialCommerce.Application.Common.Interfaces;
using ErrorOr;
using SocialCommerce.Application.Commom.Interfaces.Persistence;
using SocialCommerce.Application.Authentication.Commom;
using SocialCommerce.Domain.UserAgregate;
using MediatR;

namespace SocialCommerce.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user != null)
        {
            return Error.Conflict(description: "Username already exists");
        }

        var userResult = User.Create(request.Username, request.Password);

        if (userResult.IsError)
        {
            return userResult.Errors;
        }

        await _userRepository.AddAsync(userResult.Value);

        var token = _jwtTokenGenerator.GenerateToken(userResult.Value.Id, userResult.Value.Username);

        return new AuthResult(token, userResult.Value.Id, userResult.Value.Username);
    }
}