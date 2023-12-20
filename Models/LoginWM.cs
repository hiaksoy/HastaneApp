using System.ComponentModel.DataAnnotations;

namespace HastaneApp.Models
{
    public class LoginWM
    {

        [Required(ErrorMessage ="Kullanıcı adı giriniz")]
        [StringLength(50, ErrorMessage ="Kullanıcı adı en fazla 50 karakter olabilir")]
        public string kullaniciAdi { get; set; }

        [Required(ErrorMessage ="Şifre giriniz")]
        [MinLength(8,ErrorMessage ="Şifre 8 karakterden az olamaz")]
        [MaxLength(20,ErrorMessage ="Şifre 20 Karakterden fazla olamaz")]
        public string sifre { get; set; }
    }
}
