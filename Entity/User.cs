using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneApp.Entity
{

    [Table("Kullanici")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string adSoyad { get; set; }

        [Required]
        [StringLength(50)]
        public string kullaniciAdi { get; set; }
       
        [Required]
        [StringLength(100)]
        public string sifre { get; set; }
        
        public bool Kitli { get; set; } = false;
        public DateTime Olusturmazamani { get; set; } = DateTime.Now;

    }

  


}
