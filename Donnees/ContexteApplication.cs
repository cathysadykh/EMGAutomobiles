using Microsoft.EntityFrameworkCore;
using EMG.API.Modeles; // ou EMG.API.Modeles

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
    }
}