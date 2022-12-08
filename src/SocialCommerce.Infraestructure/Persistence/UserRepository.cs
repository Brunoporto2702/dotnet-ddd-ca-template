
using ErrorOr;
using SocialCommerce.Application.Commom.Interfaces.Persistence;
using SocialCommerce.Domain.UserAgregate;

namespace SocialCommerce.Infraestructure.Persistence;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new();
    public async Task AddAsync(User user)
    {
        _users.Add(user);
        // mock completed task
        await Task.CompletedTask;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var user = _users.FirstOrDefault(x => x.Username == username);
        // mock completed task
        await Task.CompletedTask;
        return user;
    }
}