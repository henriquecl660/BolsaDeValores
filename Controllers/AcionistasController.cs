using BolsaDeValores.Data;
using BolsaDeValores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeValores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AcionistasController : ControllerBase
    {


        public readonly DataContext _context;

        public AcionistasController(DataContext context)
        {
            _context = context;
        }
    

        [HttpGet]
        public async Task<ActionResult<List<Acionista>>> Get(int acionistaId)
        {
            var acionistas = await _context.Acionistas
                .Where(x => x.AcionistaId == acionistaId)
                .ToListAsync();

            return acionistas;
        }

        [HttpPost]
        public async Task<ActionResult<List<Acionista>>> Create(Acionista acionista)
        {
            _context.Acionistas.Add(acionista);
            await _context.SaveChangesAsync();

            return await Get(acionista.AcionistaId);
        }

        [HttpPut]
        public async Task<ActionResult<List<Acionista>>> Put(Acionista acionista)
        {
            _context.Acionistas.Update(acionista);
            await _context.SaveChangesAsync();

            return await Get(acionista.AcionistaId);
        }


        [HttpDelete]
        public async Task<ActionResult<List<Acionista>>> Delete (int acionistaId)
        {
            var acionistaBusca = await _context.Acionistas
                .Where(x => x.AcionistaId == acionistaId)
                .ToListAsync();

            if (acionistaBusca.Count != 0)
            {
                _context.Acionistas.Remove(acionistaBusca[0]);
                await _context.SaveChangesAsync();
                return await Get(acionistaId);
            }
            else
            {
                return NoContent();
            }
        }

        


    }
}
