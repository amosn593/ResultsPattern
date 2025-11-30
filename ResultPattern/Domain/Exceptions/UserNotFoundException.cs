namespace ResultPattern.Domain.Exceptions;

public class UserNotFoundException : DomainException
{
    public UserNotFoundException(int userId)
        : base($"User with ID '{userId}' was not found.")
    {
    }

    public UserNotFoundException(string identifier)
        : base($"User '{identifier}' was not found.")
    {
    }
}

public class UserAlreadyExistsException : DomainException
{
    public UserAlreadyExistsException(string email)
        : base($"A user with email '{email}' already exists.")
    {
    }
}
