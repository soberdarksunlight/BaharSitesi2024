using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Repository;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            var model = new EvSahipleri();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(EvSahipleri loginViewModel)
        {

            if (string.IsNullOrWhiteSpace(loginViewModel.EPosta) || string.IsNullOrWhiteSpace(loginViewModel.Sifre)) return BadRequest();
            
            //db ye erişmem gerekiyor. 
            var _user = _userRepository.GetUserByCreadential(loginViewModel.EPosta, loginViewModel.Sifre);

            if (_user != null)
            {
                //user bulundu. artık login olabilir. 

                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, _user.EPosta));
                claims.Add(new Claim(ClaimTypes.Role, _user.Sorumlu));
                claims.Add(new Claim(ClaimTypes.Sid, _user.DaireId.ToString()));


                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginViewModel.RememberMe
                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
                };

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
