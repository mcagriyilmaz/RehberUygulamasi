using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Client;
using RehberUygulamasi.Models;
using System.Security.Claims;

namespace RehberUygulamasi.Controllers
{
    public class LoginController : Controller
    {
        RehberContext rehberContext = new RehberContext();
        [HttpGet]
        public IActionResult GirisYap()
        {
         
            return View();
        }
        public async Task<IActionResult> GirisYap(Admin a)
        {
            var bilgiler = rehberContext.admins.FirstOrDefault(x => x.Kullanici == a.Kullanici && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name,a.Kullanici)
                };
                var useridentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

       
    }
}
