using System.ComponentModel.DataAnnotations;

namespace HastaneApp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string? AdSoyad { get; set; }
        public string kullaniciAdi { get; set; }

        public DateTime Olusturmazamani { get; set; } = DateTime.Now;

        public string Role { get; set; } = "user";

    }

    public class CreateUserModel
    {
      
        [StringLength(50, ErrorMessage = "Ad soyad en fazla 50 karakter olabilir")]
        public string AdSoyad { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string kullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre giriniz")]

        [MaxLength(20, ErrorMessage = "Şifre 20 Karakterden fazla olamaz")]
        public string sifre { get; set; }

        [Required(ErrorMessage = "Şifre giriniz")]

        [MaxLength(20, ErrorMessage = "Şifre 20 Karakterden fazla olamaz")]
        [Compare(nameof(sifre))]
        public string yenidensifre { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }

    public class EditUserModel
    {

        [StringLength(50, ErrorMessage = "Ad soyad en fazla 50 karakter olabilir")]
        public string AdSoyad { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir")]
        public string kullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }


}
