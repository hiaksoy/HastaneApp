using AutoMapper;
using HastaneApp.Entity;
using HastaneApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NETCore.Encrypt.Extensions;

namespace HastaneApp.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IConfiguration configuration, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //Database veri çekme örnek
            // List<User> kullanicilar = _databaseContext.Kullanici.ToList();

            //2. örnek
            // _databaseContext.Kullanici.Select(x => new UserModel { kullaniciAdi = x.kullaniciAdi, Olusturmazamani = x.Olusturmazamani, Role = x.Role }).ToList();

            List<UserModel> kullanicilar = _databaseContext.Kullanici.ToList().Select(x => _mapper.Map<UserModel>(x)).ToList();


            return View(kullanicilar);
        }
          private string MD5sifre(string s)
                {
                    string md5Sifre = _configuration.GetValue<string>("AppSettings:MD5Sifre");
                    string gizlisifre = s + md5Sifre;
                    string yenisifre = gizlisifre.MD5();
                    return yenisifre;
                }

        public IActionResult Create()
        {
           
            return View();
        }

      

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            /*  if (ModelState.IsValid)
              {
                  User user = _mapper.Map<User>(model);

                  _databaseContext.Kullanici.Add(user);
                  _databaseContext.SaveChanges();

                  return RedirectToAction(nameof(Index));
              }*/

            if (ModelState.IsValid)
            {
                //kullanıcı adı mevcutluğu kontrolü
                if (_databaseContext.Kullanici.Any(x => x.kullaniciAdi.ToLower() == model.kullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.kullaniciAdi), "Kullanıcı adı çoktan alınmış");
                    return View(model);
                }

                //kriptolanmış şifre oluşturma
                string yenisifre = MD5sifre(model.sifre);


                User user = new User()
                {
                    AdSoyad = model.AdSoyad,
                    kullaniciAdi = model.kullaniciAdi,
                    sifre = yenisifre

                };

                _databaseContext.Kullanici.Add(user);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }


            return View(model);
        }


        public IActionResult Edit(Guid id)
        {
            User user = _databaseContext.Kullanici.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);
            return View(model);
        }



        [HttpPost]
        public IActionResult Edit(Guid id, EditUserModel model)
        {
             if (ModelState.IsValid)
              {
                if (_databaseContext.Kullanici.Any(x => x.kullaniciAdi.ToLower() == model.kullaniciAdi.ToLower() && x.Id != id ))
                {
                    ModelState.AddModelError(nameof(model.kullaniciAdi), "Kullanıcı adı çoktan alınmış");
                    return View(model);
                }
                User user = _databaseContext.Kullanici.Find(id);

                  _mapper.Map(model, user);
                  _databaseContext.SaveChanges();

                  return RedirectToAction(nameof(Index));
              }

           


            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            
              
                User user = _databaseContext.Kullanici.Find(id);

                _databaseContext.Kullanici.Remove(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

    }
}
