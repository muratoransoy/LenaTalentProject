using LenaTalent.Entities.Models.Identity;
using LenaTalent.Entities.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LenaTalent.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Register()
        {
            if (User.Identity.Name != null)
                return RedirectToAction("Index", "Home");

            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var user = new User()
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                UserName = register.Username
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await roleManager.CreateAsync(new Role("user"));
                await userManager.AddToRoleAsync(user, "user");

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(register);
        }
        public async Task<IActionResult> Login()
        {
            if (User.Identity.Name != null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                if (login.UsernameOrEmail.Contains("@"))
                {
                    user = await userManager.FindByEmailAsync(login.UsernameOrEmail);
                }
                else
                {
                    user = await userManager.FindByNameAsync(login.UsernameOrEmail);
                }
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(login);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}