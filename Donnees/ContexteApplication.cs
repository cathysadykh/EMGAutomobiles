using Microsoft.EntityFrameworkCore;
using EMG.API.Modeles;
namespace EMG.API.Data
{
    public class ContexteApplication : DbContext
    {
        public ContexteApplication(DbContextOptions<ContexteApplication> options)
            : base(options)
        {
        }

        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<ModeleVoiture> ModelesVoiture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Voiture>()
                .HasOne(v => v.Marque)
                .WithMany()
                .HasForeignKey(v => v.MarqueId);

            modelBuilder.Entity<Voiture>()
                .HasOne(v => v.Modele)
                .WithMany()
                .HasForeignKey(v => v.ModeleId);

            modelBuilder.Entity<ModeleVoiture>()
                .HasOne(m => m.Marque)
                .WithMany(m => m.Modeles)
                .HasForeignKey(m => m.MarqueId);
        }
    }
}