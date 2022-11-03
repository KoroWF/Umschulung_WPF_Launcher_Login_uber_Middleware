using Microsoft.EntityFrameworkCore;
using Model;

namespace BenutzerService.DB
{
    public class DatenbankContext :DbContext
    {
        public DbSet<Nutzer> NutzerListe { get; set; }
        public DbSet<Rolle> Rollen { get; set; }
        public DbSet<Token> Tokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Benutzerdaten.db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Nutzer>()
                .HasIndex(u => u.uid)
                .IsUnique();
        }
    }
}
