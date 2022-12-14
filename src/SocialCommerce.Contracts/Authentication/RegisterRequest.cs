using System.Text.Json.Serialization;

namespace SocialCommerce.Contracts.Authentication;


public class RegisterRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    public RegisterRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }
}