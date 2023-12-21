using Microsoft.EntityFrameworkCore;

namespace HastaneApp.Entity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Kullanici { get; set; }
    }
}
