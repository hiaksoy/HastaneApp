using HastaneApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneApp.Controllers
{
    public class AccCtrl : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginWM model)
        {
            if (ModelState.IsValid)
            {
                //giriş işlemleri
            }

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterWM model)
        {


            if (ModelState.IsValid)
            {
                //register işlemleri
            }
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
