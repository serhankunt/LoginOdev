using LoginOdev.Domain.Events;
using LoginOdev.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace LoginOdev.Application.Features.Auth.Register;
public sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExist = await userManager.Users.AnyAsync(p=>p.Email == request.Email);
        if(isEmailExist)
        {
            return Result<string>.Failure("Email adresi kullanılmış");
        }

        bool isIdentityNumberExist = await userManager.Users.AnyAsync(p => p.IdentityNumber == request.IdentityNumber);
        if(isIdentityNumberExist)
        {
            return Result<string>.Failure("Kimlik numarası daha önce kullanılmış");
        }

        bool isUserNameExist = await userManager.Users.AnyAsync(p=>p.UserName == request.UserName); 
        if(isUserNameExist)
        {
            return Result<string>.Failure("Kullanıcı adı daha önce kullanılmış");
        }


        AppUser user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName,
            IdentityNumber = request.IdentityNumber
        };

        IdentityResult result = await userManager.CreateAsync(user,request.Password);

        if(!result.Succeeded)
        {
            List<string> errorMessages = result.Errors.Select(s=>s.Description).ToList();
            return Result<string>.Failure(errorMessages);
        }

        await mediator.Publish(new AuthDomainEvent(user));

        return Result<string>.Succeed("Kullanıcı başarılı şekilde oluşturuldu");
    }
}
