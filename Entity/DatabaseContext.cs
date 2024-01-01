using Microsoft.EntityFrameworkCore;

namespace HastaneApp.Entity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Kullanici { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }

        public DbSet<Randevu> Randevular { get; set; }


    }
}
