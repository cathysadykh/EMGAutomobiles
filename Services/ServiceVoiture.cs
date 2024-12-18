using EMG.API.Data; 
using EMG.API.Modeles;
using Microsoft.EntityFrameworkCore;
namespace EMG.API.Services
{
    public class ServiceVoiture : IServiceVoiture
    {
        private readonly ContexteApplication _contexte;

        public ServiceVoiture(ContexteApplication contexte)
        {
            _contexte = contexte;
        }

        public async Task<IEnumerable<Voiture>> ObtenirToutesVoitures()
        {
            return await _contexte.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .ToListAsync();
        }

        public async Task<Voiture> ObtenirVoitureParId(int id)
        {
            return await _contexte.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Voiture> AjouterVoiture(Voiture voiture)
        {
            _contexte.Voitures.Add(voiture);
            await _contexte.SaveChangesAsync();
            return voiture;
        }

        public async Task<Voiture> ModifierVoiture(int id, Voiture voiture)
        {
            var voitureExistante = await _contexte.Voitures.FindAsync(id);
            if (voitureExistante == null)
                return null;

            voitureExistante.MarqueId = voiture.MarqueId;
            voitureExistante.ModeleId = voiture.ModeleId;
            voitureExistante.Annee = voiture.Annee;
            voitureExistante.Prix = voiture.Prix;
            voitureExistante.Description = voiture.Description;
            voitureExistante.UrlImage = voiture.UrlImage;
            voitureExistante.EstDisponible = voiture.EstDisponible;

            await _contexte.SaveChangesAsync();
            return voitureExistante;
        }

        public async Task<bool> SupprimerVoiture(int id)
        {
            var voiture = await _contexte.Voitures.FindAsync(id);
            if (voiture == null)
                return false;

            _contexte.Voitures.Remove(voiture);
            await _contexte.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Voiture>> ObtenirVoituresDisponibles()
        {
            return await _contexte.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .Where(v => v.EstDisponible)
                .ToListAsync();
        }

        public async Task<bool> MarquerCommeIndisponible(int id)
        {
            var voiture = await _contexte.Voitures.FindAsync(id);
            if (voiture == null)
                return false;

            voiture.EstDisponible = false;
            await _contexte.SaveChangesAsync();
            return true;
        }
    }
}
