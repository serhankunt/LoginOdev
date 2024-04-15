using LoginOdev.Application.Features.Auth.Login;
using LoginOdev.Application.Features.Auth.Register;
using LoginOdev.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoginOdev.Presentation.Controllers;
public sealed class AuthController: ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
   
}
