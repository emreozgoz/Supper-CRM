using Microsoft.AspNetCore.Mvc;

namespace SupperCRM.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
