using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ReviewSite.Context;
using ReviewSite.Models;
using System.Security.Claims;

namespace ReviewSite.Controllers
{
    public class LogInController : Controller
    {
        private static string _returnUrl;

        private readonly RestaurantContext _context;

        public LogInController(RestaurantContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            string returnUrl = HttpContext.Request.Query["ReturnUrl"];
            _returnUrl = returnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index");
        }
        public async Task<ActionResult> ProcessLogin(UserModel userModel)
        {
            var user = _context.UserModel.Where(u => u.UserName.ToLower() == userModel.UserName.ToLower());
            if (user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.UserName),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authproperties = new AuthenticationProperties
                {
                    RedirectUri = "/Home/Index",
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authproperties);
                if (string.IsNullOrEmpty(_returnUrl))
                {
                    return Redirect("/Home");
                }
                return Redirect(_returnUrl);

            }
            return Redirect("/Home/Error");

        }
        
    }
}
