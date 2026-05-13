using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SKATEPARK_app.Models;
using SKATEPARK_app.Models.register;
using System.Diagnostics;

namespace SKATEPARK_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    ProfileType = model.ProfileType,
                    DisplayName = model.DisplayName,
                    AvatarImageID = Guid.NewGuid().ToString(),
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userID = user.Id, token = token }, Request.Scheme);

                }

                //

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
