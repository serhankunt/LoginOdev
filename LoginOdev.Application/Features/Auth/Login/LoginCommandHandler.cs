using LoginOdev.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace LoginOdev.Application.Features.Auth.Login;
internal class LoginCommandHandler(UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //var user = await userManager.FindByEmailAsync(request.UserNameOrEmail);
        var userByEmail = await userManager.FindByEmailAsync(request.UserNameOrEmail);
        var userByName = await userManager.FindByNameAsync(request.UserNameOrEmail);

        var user = userByEmail ?? userByName;

        if (user == null)
        {
            return Result<string>.Failure("Email adresi ya da kullanıcı adı bulunamadı. ");
        }

        //bool isEmailExist = await userManager.Users.AnyAsync(p => p.Email == request.UserNameOrEmail || p.UserName == request.UserNameOrEmail);
        //if (!isEmailExist)
        //{
        //    return Result<string>.Failure("Email adresi bulunamadı");
        //}

        bool passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);

        if(passwordCheck)
        {
            return Result<string>.Succeed("Giriş işlemi başarıyla sonuçlandı");
        }
        else
        {
            return Result<string>.Failure("Şifre hatalı");
        }
    }
}
