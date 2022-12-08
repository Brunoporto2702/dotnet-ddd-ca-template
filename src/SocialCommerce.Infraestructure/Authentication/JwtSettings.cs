namespace SocialCommerce.Infraestructure.Authentication;

public class JwtSettings
{
    public static string SectionName { get; set; } = "JwtSettings";
    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpirationDays { get; set; }
}