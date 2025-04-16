using JwtAuthDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDotNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)    
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
