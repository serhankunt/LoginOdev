using LoginOdev.Domain.Models;
using MediatR;

namespace LoginOdev.Domain.Events;
public sealed class AuthDomainEvent :INotification
{
    public readonly AppUser _user;
    public AuthDomainEvent(AppUser user)
    {
        _user = user;   
    }
}
