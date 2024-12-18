using Microsoft.AspNetCore.Mvc;
using EMG.API.Services;
using EMG.API.Modeles;

namespace EMG.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoitureController : ControllerBase
    {
        private readonly IServiceVoiture _serviceVoiture;

        public VoitureController(IServiceVoiture serviceVoiture)
        {
            _serviceVoiture = serviceVoiture;
        }

        /// <summary>
        /// Obtenir toutes les voitures
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voiture>>> ObtenirToutesVoitures()
        {
            var voitures = await _serviceVoiture.ObtenirToutesVoitures();
            return Ok(voitures);
        }

        /// <summary>
        /// Obtenir une voiture par son ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Voiture>> ObtenirVoitureParId(int id)
        {
            var voiture = await _serviceVoiture.ObtenirVoitureParId(id);
            if (voiture == null)
                return NotFound();

            return Ok(voiture);
        }

        /// <summary>
        /// Ajouter une nouvelle voiture
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Voiture>> AjouterVoiture(Voiture voiture)
        {
            var nouvelleVoiture = await _serviceVoiture.AjouterVoiture(voiture);
            return CreatedAtAction(nameof(ObtenirVoitureParId), new { id = nouvelleVoiture.Id }, nouvelleVoiture);
        }

        /// <summary>
        /// Modifier une voiture existante
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifierVoiture(int id, Voiture voiture)
        {
            var voitureModifiee = await _serviceVoiture.ModifierVoiture(id, voiture);
            if (voitureModifiee == null)
                return NotFound();

            return Ok(voitureModifiee);
        }

        /// <summary>
        /// Supprimer une voiture
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> SupprimerVoiture(int id)
        {
            var resultat = await _serviceVoiture.SupprimerVoiture(id);
            if (!resultat)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Obtenir toutes les voitures disponibles
        /// </summary>
        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<Voiture>>> ObtenirVoituresDisponibles()
        {
            var voitures = await _serviceVoiture.ObtenirVoituresDisponibles();
            return Ok(voitures);
        }

        /// <summary>
        /// Marquer une voiture comme indisponible
        /// </summary>
        [HttpPatch("{id}/indisponible")]
        public async Task<IActionResult> MarquerCommeIndisponible(int id)
        {
            var resultat = await _serviceVoiture.MarquerCommeIndisponible(id);
            if (!resultat)
                return NotFound();

            return NoContent();
        }
    }
}