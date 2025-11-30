namespace ResultPattern.Domain.Errors;

public sealed record Error(string Code, string Message, string? Detail = null)
{
    public static Error None => new("None", string.Empty);
}
