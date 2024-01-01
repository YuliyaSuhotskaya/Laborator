using Laborator.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Laborator.Controllers
{
    public class ImageController : Controller
    {
        
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public ImageController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task <IActionResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Avatar != null)
                return File(user.Avatar, "image/*");
            else
            {
                var avatarPath = "/Images/anonymous.png";

                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
               .CreateReadStream(), "image/*");
            }
        }
    }
}
