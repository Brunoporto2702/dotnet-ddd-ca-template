namespace SocialCommerce.Application.Authentication.Commom;


public record AuthResult(
    string Token,
    Guid UserId,
    string Username);