using ErrorOr;
using MediatR;
using SocialCommerce.Application.Authentication.Commom;

namespace SocialCommerce.Application.Authentication.Commands;

public record RegisterCommand(
    string Username,
    string Password) : IRequest<ErrorOr<AuthResult>>;