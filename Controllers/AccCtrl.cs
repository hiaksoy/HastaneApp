using HastaneApp.Entity;
using HastaneApp.Models;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;

namespace HastaneApp.Controllers
{
    public class AccCtrl : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public AccCtrl(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginWM model)
        {
            if (ModelState.IsValid)
            {
                string md5Sifre = _configuration.GetValue<string>("AppSettings:MD5Sifre");
                string gizlisifre = model.sifre + md5Sifre;
                string yenisifre = gizlisifre.MD5();
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
                if(_databaseContext.Kullanici.Any(x => x.kullaniciAdi.ToLower() == model.kullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.kullaniciAdi), "Kullanıcı adı çoktan alınmış");
                    View(model);
                }

                string md5Sifre = _configuration.GetValue<string>("AppSettings:MD5Sifre");
                string gizlisifre = model.sifre + md5Sifre;
                string yenisifre = gizlisifre.MD5();

                User user = new User()
                {
                    kullaniciAdi = model.kullaniciAdi ,
                    sifre = yenisifre              
                        
                };

                _databaseContext.Kullanici.Add(user);
                int sayac = _databaseContext.SaveChanges();

                if (sayac == 0 )
                {
                    ModelState.AddModelError("", "Kullanıcı oluşturulamadı.");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
