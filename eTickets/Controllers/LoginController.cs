using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public LoginController(UserManager<IdentityUser>userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //if (!userManager.Users.Any())
            //{
            //    // Create a default user with specific credentials and roles
            //    var defaultUser = new IdentityUser
            //    {
            //        UserName = "joetiger22222",
            //        Email = "joetiger22222@gmail.com",
            //    };
            //    var defaultResult = await userManager.CreateAsync(defaultUser, "123456");

            //    if (defaultResult.Succeeded)
            //    {
            //        var defaultRoles = new List<string> { "Writer" };
            //        await userManager.AddToRolesAsync(defaultUser, defaultRoles);
            //        return Ok("Default user created successfully");
            //    }
            //    else
            //    {
            //        // Handle default user creation failure
            //        return BadRequest("Error creating default user");
            //    }
            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] User admin)
        {
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user != null)
            {
                var checkPass = await userManager.CheckPasswordAsync(user, admin.Password);
                if (checkPass)
                {
                    // Check the user's role
                    var userRoles = await userManager.GetRolesAsync(user);
                    if (userRoles.Contains("Writer"))
                    {
                        //return Ok(new { UserId = user.Id, Role = "Admin" });
                        HttpContext.Session.SetString("UserRoles", string.Join(",", userRoles));

                // Redirect to the Movies/Index action
                return RedirectToAction("Index", "Movies");
                    }
                    else
                    {
                        return BadRequest("User Not Found");
                    }

                }
            }
            return RedirectToAction(nameof(Index));
        }
            
        
    }
}
