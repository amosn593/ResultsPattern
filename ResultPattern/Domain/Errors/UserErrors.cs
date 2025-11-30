namespace ResultPattern.Domain.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        Code: "User.NotFound",
        Message: "The specified user was not found."
    );

    public static readonly Error AlreadyExists = new(
        Code: "User.Exists",
        Message: "A user with the same email already exists."
    );
}
