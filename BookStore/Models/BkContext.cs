using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BkContext : DbContext
    {
        public DbSet<Book> Bookes { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BkContext(DbContextOptions<BkContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
