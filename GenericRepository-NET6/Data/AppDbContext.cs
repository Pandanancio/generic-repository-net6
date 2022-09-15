using GenericRepository_NET6.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository_NET6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
    }
}
