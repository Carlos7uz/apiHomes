using Microsoft.EntityFrameworkCore;

namespace apiHomes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Home> Homes { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
