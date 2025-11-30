using Microsoft.EntityFrameworkCore;
using ResultPattern.Domain.Errors;
using ResultPattern.Domain.Interfaces;
using ResultPattern.Domain.Models;
using ResultPattern.Domain.Results;
using ResultPattern.Infrastructure.Data;

namespace ResultPattern.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;


    public UserRepository(AppDbContext db)
    {
        _db = db;
    }


    public async Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _db.Users.AddAsync(user, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return Result<User>.Ok(user);
    }


    public async Task<Result<User?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (user == null)
        {
            return Result<User?>.Fail(UserErrors.NotFound);
        }
        return Result<User?>.Ok(user);
    }


    public async Task<Result<User?>> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == normalized, cancellationToken);
        return Result<User?>.Ok(user);
    }


    public async Task<Result> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
