using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proniaaa.DAL;
using Proniaaa.Helpers.Enums;
using Proniaaa.Models;
using Proniaaa.ViewModels.Account;

namespace Proniaaa.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _usermanager = usermanager;
           _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)

        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
               Name=registerVm.Name,
               Surname=registerVm.Surname,
               UserName=registerVm.Username,
               Email=registerVm.Email,
            };
          var result= await _usermanager.CreateAsync(appUser, registerVm.Password);
            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
          await  _usermanager.AddToRoleAsync(appUser, UserRoles.Admin.ToString());
       




            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm,string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _usermanager.FindByEmailAsync(loginVm.EmailOrUsername)
                ?? await _usermanager.FindByNameAsync(loginVm.EmailOrUsername);
            if (user is null)
            {
                ModelState.AddModelError("","UsernameOrEmail ve ya Password sehvdir!");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginVm.Password,true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("","yeniden sinayin");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UsernameOrEmail ve ya Password sehvdir!");
                return View();
            }

            await _signInManager.SignInAsync(user, loginVm.Remember);

            if (ReturnUrl != null)
            {
                return RedirectToAction(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
          foreach(var item in Enum.GetValues(typeof(UserRoles)))
            {
                await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = item.ToString()
                });
            }
          



            return RedirectToAction("Index", "Home");
        }
    }
}
