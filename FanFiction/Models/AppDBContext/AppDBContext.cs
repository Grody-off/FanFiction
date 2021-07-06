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


            modelBuilder.Entity<Сomposition>()
               .HasMany(b => b.Chapters)
               .WithOne(b => b.Сomposition)
               .HasForeignKey(b => b.CompositionId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
                .ToTable("Chapters")
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Chapter>()
                .HasOne(b => b.Сomposition)
                .WithMany(b => b.Chapters)
                .HasForeignKey(b => b.CompositionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Сomposition> Сomposition { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
    }
}
