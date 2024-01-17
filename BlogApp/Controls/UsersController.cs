using BlogApp.Data.Abstract;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controls
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return View("Index", "Posts");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                var isUser = _userRepository.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (isUser != null)
                {
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.Email, isUser.Email ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                    if (isUser.Email == "info@neronege.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    var claimIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(claimIdentity), authProperties);
                    return RedirectToAction("Index", "Posts");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            //cookie'nin silinmesini sağlars
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Users");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {

                bool newUser = _userRepository.Users.Where(x => x.Email != model.Email || x.UserName != model.UserName).Any();

                if (newUser)
                {
                    _userRepository.CreateUser(new Entity.User
                    {
                        Email = model.Email,
                        UserName = model.UserName,
                        Password = model.Password,
                        Name = model.Name,
                        Image = "user.png"

                    });
                    return RedirectToAction("Login");
                }



            }
            else
            {
                ModelState.AddModelError("", "UserName ya da Email kullanımda");
            }
            return View(model);
        }
        public IActionResult Register()
        {

            return View();
        }


    }
}

