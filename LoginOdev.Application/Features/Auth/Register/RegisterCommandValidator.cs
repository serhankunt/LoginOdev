using FluentValidation;
using LoginOdev.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginOdev.Application.Features.Auth.Register;
public  class RegisterCommandValidator :AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(UserManager<AppUser> userManager)
    {
        RuleFor(p => p.Email).EmailAddress().WithMessage("Email address already taken");
        RuleFor(p => p.UserName).MinimumLength(3).WithMessage("User name must be at least 3 letters");

        RuleFor(p => p.FirstName).MinimumLength(3);
        RuleFor(p => p.LastName).MinimumLength(2);
    }
}
