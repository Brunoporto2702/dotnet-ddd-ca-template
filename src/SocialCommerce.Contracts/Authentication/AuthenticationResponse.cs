namespace SocialCommerce.Contracts.Authentication;


public record AuthenticationResponse(
    string Token,
    Guid UserId,
    string Username);