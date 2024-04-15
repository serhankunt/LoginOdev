using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginOdev.Domain.Models;
public sealed class AppRole : IdentityRole<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;

}
