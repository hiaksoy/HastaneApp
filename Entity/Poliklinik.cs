using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneApp.Entity
{
    [Table("Poliklinikler")]
    public class Poliklinik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

    }
}
