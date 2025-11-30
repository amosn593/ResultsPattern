using FluentValidation;
using ResultPattern.Domain.DTOs;
using ResultPattern.Domain.Models;

namespace ResultPattern.Validators;

public class UserValidator : AbstractValidator<UserCreationDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");
        RuleFor(x => x.AvatarUrl)
            .MaximumLength(250).WithMessage("Avatar URL must not exceed 250 characters.")
            .When(x => !string.IsNullOrEmpty(x.AvatarUrl));
    }
}
