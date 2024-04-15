using LoginOdev.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace LoginOdev.Domain.Models;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName {get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName,LastName);
    public string IdentityNumber { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
}
