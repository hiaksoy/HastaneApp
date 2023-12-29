using HastaneApp.Entity;
using HastaneApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;

namespace HastaneApp.Controllers
{
    [Authorize]
    public class AccCtrl : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public AccCtrl(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginWM model)
        {
            //giriş işlemleri
            if (ModelState.IsValid)
            {
                string md5Sifre = _configuration.GetValue<string>("AppSettings:MD5Sifre");
                string gizlisifre = model.sifre + md5Sifre;
                string yenisifre = gizlisifre.MD5();

                User user = _databaseContext.Kullanici.SingleOrDefault(x => x.kullaniciAdi.ToLower() == model.kullaniciAdi.ToLower() && x.sifre == yenisifre);

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("kullaniciAdi", user.kullaniciAdi.ToString()));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterWM model)
        {
            //kayıt işlemleri

            if (ModelState.IsValid)
            {
                //kullanıcı adı mevcutluğu kontrolü
                if(_databaseContext.Kullanici.Any(x => x.kullaniciAdi.ToLower() == model.kullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.kullaniciAdi), "Kullanıcı adı çoktan alınmış");
                    View(model);
                }

                //kriptolanmış şifre oluşturma
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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}
