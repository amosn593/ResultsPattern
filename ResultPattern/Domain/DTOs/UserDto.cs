namespace ResultPattern.Domain.DTOs;

public record UserDto(int Id, string Email, string FullName, string? AvatarUrl);

public record UserCreationDto(string Email, string FullName, string? AvatarUrl);
