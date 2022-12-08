using ErrorOr;
using SocialCommerce.Domain.UserAgregate;

namespace SocialCommerce.Application.Commom.Interfaces.Persistence;

public interface IUserRepository
{
    // Task<User> GetAsync(Guid id);
    Task<User?> GetByUsernameAsync(string username);
    // Task<User> GetAsync(string username, string password);
    Task AddAsync(User user);
    // Task UpdateAsync(User user);
    // Task DeleteAsync(User user);
}