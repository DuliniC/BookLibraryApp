using BookLibrary.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
