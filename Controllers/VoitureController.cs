using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMG.API.Data;
using EMG.API.Modeles;
using EMG.API.DTOs;

namespace EMG.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoitureController : ControllerBase
    {
        private readonly ContexteApplication _contexte;

        public VoitureController(ContexteApplication contexte)
        {
            _contexte = contexte;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voiture>>> ObtenirToutesVoitures()
        {
            return await _contexte.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voiture>> ObtenirVoitureParId(int id)
        {
            var voiture = await _contexte.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (voiture == null)
                return NotFound();

            return voiture;
        }

        [HttpPost]
        public async Task<ActionResult<Voiture>> AjouterVoiture(VoitureCreationDto voitureDto)
        {
            var voiture = new Voiture
            {
                MarqueId = voitureDto.MarqueId,
                ModeleId = voitureDto.ModeleId,
                Annee = voitureDto.Annee,
                Prix = voitureDto.Prix,
                Description = voitureDto.Description,
                UrlImage = voitureDto.UrlImage,
                EstDisponible = voitureDto.EstDisponible
            };

            _contexte.Voitures.Add(voiture);
            await _contexte.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenirVoitureParId), new { id = voiture.Id }, voiture);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifierVoiture(int id, VoitureCreationDto voitureDto)
        {
            var voiture = await _contexte.Voitures.FindAsync(id);
            if (voiture == null)
                return NotFound();

            voiture.MarqueId = voitureDto.MarqueId;
            voiture.ModeleId = voitureDto.ModeleId;
            voiture.Annee = voitureDto.Annee;
            voiture.Prix = voitureDto.Prix;
            voiture.Description = voitureDto.Description;
            voiture.UrlImage = voitureDto.UrlImage;
            voiture.EstDisponible = voitureDto.EstDisponible;

            await _contexte.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SupprimerVoiture(int id)
        {
            var voiture = await _contexte.Voitures.FindAsync(id);
            if (voiture == null)
                return NotFound();

            _contexte.Voitures.Remove(voiture);
            await _contexte.SaveChangesAsync();

            return NoContent();
        }
    }
}