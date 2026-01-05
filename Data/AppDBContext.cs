using Microsoft.EntityFrameworkCore;
using RegistrationForm.Model;

namespace RegistrationForm.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}

