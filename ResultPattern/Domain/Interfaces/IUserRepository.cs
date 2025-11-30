using ResultPattern.Domain.Models;
using ResultPattern.Domain.Results;

namespace ResultPattern.Domain.Interfaces;

public interface IUserRepository
{
    Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken = default);
    Task<Result<User?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<User?>> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(User user, CancellationToken cancellationToken = default);
}
