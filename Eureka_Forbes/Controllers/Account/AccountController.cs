using Microsoft.AspNetCore.Mvc;

namespace Eureka_Forbes.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
