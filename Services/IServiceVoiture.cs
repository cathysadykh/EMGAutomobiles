using EMG.API.Modeles; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMG.API.Services
{
    public interface IServiceVoiture
    {
        Task<IEnumerable<Voiture>> ObtenirToutesVoitures();
        Task<Voiture> ObtenirVoitureParId(int id);
        Task<Voiture> AjouterVoiture(Voiture voiture);
        Task<Voiture> ModifierVoiture(int id, Voiture voiture);
        Task<bool> SupprimerVoiture(int id);
    }
}