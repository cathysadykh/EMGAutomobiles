using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMG.API.Data;           // Pour ContexteApplication
using EMG.API.Modeles ;       // Pour Marque
using EMG.API.DTOs;          // Pour MarqueCreationDto
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMG.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MarqueController : ControllerBase
{
    private readonly ContexteApplication _contexte;

    public MarqueController(ContexteApplication contexte)
    {
        _contexte = contexte;
    }

    [HttpPost]
    public async Task<ActionResult<Marque>> AjouterMarque([FromBody] MarqueCreationDto marqueDto)
    {
        var marque = new Marque
        {
            Nom = marqueDto.Nom
        };

        _contexte.Marques.Add(marque);
        await _contexte.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenirMarqueParId), new { id = marque.Id }, marque);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marque>>> ObtenirToutesMarques()
    {
        return await _contexte.Marques.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marque>> ObtenirMarqueParId(int id)
    {
        var marque = await _contexte.Marques.FindAsync(id);
        if (marque == null)
            return NotFound();

        return marque;
    }
}