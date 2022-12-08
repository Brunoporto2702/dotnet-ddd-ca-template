using ErrorOr;

namespace SocialCommerce.Domain.UserAgregate;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; private set; }
    public string Password { get; private set; }

    private User(string username, string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
    }

    public static ErrorOr<User> Create(string username, string password)
    {
        List<Error> errors = new();

        if (string.IsNullOrWhiteSpace(username))
        {
            errors.Add(Error.Validation(description: "Username is required"));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            errors.Add(Error.Validation(description: "Password is required"));
        }

        if (errors.Any())
        {
            return errors;
        }

        return new User(username, password);
    }
}