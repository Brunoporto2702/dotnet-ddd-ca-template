using System.Text.Json.Serialization;

namespace SocialCommerce.Contracts.Authentication;


public class LoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }
}