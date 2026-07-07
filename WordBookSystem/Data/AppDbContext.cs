using Microsoft.EntityFrameworkCore;
using WordBookSystem.Models;

namespace WordBookSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<WordBooks> WordBooks { get; set; } = null!;
        public DbSet<Words> Words { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WordBooks>()
                .Property(x => x.WordBookName)
                .HasDefaultValue("無名の単語帳");

            modelBuilder.Entity<WordBooks>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<WordBooks>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}