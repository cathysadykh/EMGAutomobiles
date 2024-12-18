using EMG.API.Modeles;
namespace EMG.API.Services
{
    public interface IServiceVoiture
    {
        Task<IEnumerable<Voiture>> ObtenirToutesVoitures();
        Task<Voiture> ObtenirVoitureParId(int id);
        Task<Voiture> AjouterVoiture(Voiture voiture);
        Task<Voiture> ModifierVoiture(int id, Voiture voiture);
        Task<bool> SupprimerVoiture(int id);
        Task<IEnumerable<Voiture>> ObtenirVoituresDisponibles();
        Task<bool> MarquerCommeIndisponible(int id);
    }
}
