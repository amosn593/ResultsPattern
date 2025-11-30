using ResultPattern.Domain.Results;

namespace ResultPattern.Domain.Models;

public sealed class User
{
    public int Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string FullName { get; private set; } = null!;
    public string? AvatarUrl { get; private set; }


    // Private ctor for EF / ORM
    private User() { }


    // Factory with validation returning Result<User>
    public static Result<User> Create(string email, string fullName)
    {
        
        var user = new User
        {
            Email = email.Trim().ToLowerInvariant(),
            FullName = fullName.Trim()
        };


        return Result<User>.Ok(user);
    }


    public Result UpdateProfile(string fullName)
    {
        
        FullName = fullName.Trim();
        return Result.Ok();
    }


    public void SetAvatar(string url)
    {
        // This is an infrastructure-level operation that we accept as "trusted" by the domain
        AvatarUrl = url;
    }
}
