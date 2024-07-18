using BolsaDeValores.Data;
using BolsaDeValores.DTO.Corretora;
using BolsaDeValores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BolsaDeValores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretorasController : ControllerBase
    {
        public readonly DataContext _context;

        public CorretorasController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("/CriarCorretora")]
        public async Task<ActionResult<List<Corretora>>> Create(CreateCorretoraDTO createCorretoraDTO)
        {


            List<Carteira> ListaCarteiras = new List<Carteira>();
            foreach(int carteiraId in createCorretoraDTO.Carteiras)
            {
                var carteira = await _context.Carteiras.Where(x => x.CarteiraId == carteiraId).ToListAsync();
                ListaCarteiras.Add(carteira[0]);
            }

            Corretora corretora = new Corretora();
            corretora.CorretoraId = createCorretoraDTO.CorretoraId;
            corretora.Nome = createCorretoraDTO.Nome;
            corretora.RazaoSocial = createCorretoraDTO.RazaoSocial;
            corretora.PossuiOutrasCorretoras = createCorretoraDTO.PossuiOutrasCorretoras;
            corretora.Carteiras = ListaCarteiras;

            _context.Corretora.Add(corretora);
            await _context.SaveChangesAsync();

            return await Get(corretora.CorretoraId);
        }

        [HttpGet("/VizualizarCorretora")]
        public async Task<ActionResult<List<Corretora>>> Get (int corretoraId)
        {
            var corretoras = await _context.Corretora
                .Where(x => x.CorretoraId == corretoraId)
                .ToListAsync();

            return corretoras;
        }

        [HttpPut("/AtualizarCorretora")]
        public async Task<ActionResult<List<Corretora>>> Update (UpdateCorretoraDTO updateCorretoraDTO)
        {

            List<Carteira> ListaCarteiras = new List<Carteira>();
            foreach (int carteiraId in updateCorretoraDTO.Carteiras)
            {
                var carteira = await _context.Carteiras.Where(x => x.CarteiraId == carteiraId).ToListAsync();
                ListaCarteiras.Add(carteira[0]);
            }

            Corretora corretora = new Corretora();
            corretora.CorretoraId = updateCorretoraDTO.CorretoraId;
            corretora.Nome = updateCorretoraDTO.Nome;
            corretora.RazaoSocial = updateCorretoraDTO.RazaoSocial;
            corretora.PossuiOutrasCorretoras = updateCorretoraDTO.PossuiOutrasCorretoras;
            corretora.Carteiras = ListaCarteiras;

            _context.Corretora.Update(corretora);
            await _context.SaveChangesAsync();

            return await Get(corretora.CorretoraId);
        }

        [HttpDelete("/DeletarCorretora")]
        public async Task<ActionResult<List<Corretora>>> Delete (int corretoraId)
        {
            var corretora = await _context.Corretora.Where(x => x.CorretoraId== corretoraId).ToListAsync();
            List<Carteira> ListaCarteiras = new List<Carteira>();


            Corretora novaCorretora = new Corretora();
            novaCorretora = corretora[0];


            _context.Corretora.Remove(novaCorretora);
            await _context.SaveChangesAsync();
            
            return  NoContent();
            
           
            

        }

    }
}
