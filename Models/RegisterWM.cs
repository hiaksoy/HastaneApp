using System.ComponentModel.DataAnnotations;

namespace HastaneApp.Models
{
    public class RegisterWM
    {

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
    }
}
