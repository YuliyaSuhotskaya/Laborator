using Microsoft.AspNetCore.Identity;
namespace Laborator.Models
{
	public class ApplicationUser:IdentityUser
	{
		public byte[]? Avatar { get; set; }
	}
}
