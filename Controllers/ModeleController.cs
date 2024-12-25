// Controllers/ModeleController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMG.API.Data;
using EMG.API.Modeles;
using EMG.API.DTOs;

namespace EMG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeleController : ControllerBase
    {
        private readonly ContexteApplication _contexte;

        public ModeleController(ContexteApplication contexte)
        {
            _contexte = contexte;
        }

        [HttpPost]
        public async Task<ActionResult<ModeleVoiture>> AjouterModele([FromBody] ModeleCreationDto modeleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modele = new ModeleVoiture
            {
                Nom = modeleDto.Nom,
                MarqueId = modeleDto.MarqueId
            };

            _contexte.ModelesVoiture.Add(modele);
            await _contexte.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenirModeleParId), new { id = modele.Id }, modele);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModeleVoiture>> ObtenirModeleParId(int id)
        {
            var modele = await _contexte.ModelesVoiture
                .Include(m => m.Marque)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modele == null)
                return NotFound();

            return modele;
        }
    }
}