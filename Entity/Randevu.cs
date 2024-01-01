using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneApp.Entity
{

    [Table("Randevular")]
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Doktor { get; set; }

        [Required]
        [StringLength(50)]
        public string Gun { get; set; }

        [Required]
        [StringLength(50)]
        public string Saat { get; set; }

    }

  


}
