using MediatR;
using TS.Result;

namespace LoginOdev.Application.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string IdentityNumber,
    string UserName,
    string Password): IRequest<Result<string>>;

