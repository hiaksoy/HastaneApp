using Microsoft.AspNetCore.Mvc;

namespace HastaneApp.Controllers
{
    public class AccCtrl : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
