using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneApp.Entity
{
    [Table("Doktorlar")]
    public class Doktor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required]
        [StringLength(50)]
        public string Poliklinik { get; set; }

        [Required]
        [StringLength(50)]
        public string CalismaGunleri { get; set; }

        [Required]
        [StringLength(50)]
        public string CalismaSaatleri { get; set; }


    }
}
