using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Models.AppDBContext
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Сomposition>()
               .ToTable("Compositions")
               .Property(q => q.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Chapter>()
                .ToTable("Chapters")
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Сomposition> Сomposition { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
    }
}
