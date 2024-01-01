using HastaneApp.Entity;
using HastaneApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.ComponentModel.DataAnnotations;
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
                string yenisifre = MD5sifre(model.sifre);

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

        private string MD5sifre(string s)
        {
            string md5Sifre = _configuration.GetValue<string>("AppSettings:MD5Sifre");
            string gizlisifre = s + md5Sifre;
            string yenisifre = gizlisifre.MD5();
            return yenisifre;
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
                string yenisifre = MD5sifre(model.sifre);


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
            DataLoader();

            return View();
        }

        private void DataLoader()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Kullanici.SingleOrDefault(x => x.Id == userid);

            ViewData["kullaniciAdi"] = user.kullaniciAdi;
        }

        [HttpPost]
        public IActionResult UsernameUpdate([Required][StringLength(50)]string kullaniciAdi)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Kullanici.SingleOrDefault(x => x.Id == userid);

                user.kullaniciAdi = kullaniciAdi;
                _databaseContext.SaveChanges();

                ViewData["result"] = "usernameChanged";
            }

            DataLoader();
            return View("Profile");
        }

        [HttpPost]
        public IActionResult PasswordUpdate([Required][MaxLength(20)] string sifre)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Kullanici.SingleOrDefault(x => x.Id == userid);

                string yenisifre = MD5sifre(sifre);

                user.sifre = yenisifre;
                _databaseContext.SaveChanges();

                ViewData["result"] = "passChanged";
            }

            DataLoader();
            return View("Profile");
        }



        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}
