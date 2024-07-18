using BolsaDeValores.Data;
using BolsaDeValores.DTO.Carteira;
using BolsaDeValores.Migrations;
using BolsaDeValores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeValores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarteiraController : ControllerBase
    {
        public readonly DataContext _context;

        public CarteiraController(DataContext context)
        {
            _context = context;
        }

        [HttpPut("/AtualizarCarteira")]

        public async Task<ActionResult<List<Carteira>>> Put (UpdateCarteiraDTO updateCarteiraDTO)
        {
            var acionista = await _context.Acionistas
                .Where(x => x.AcionistaId == updateCarteiraDTO.AcionistaId)
                .ToListAsync();

            if(acionista.Count == 0)
            {
                return NotFound("Acionista não encontrado");
            }

            if(updateCarteiraDTO.Acoes.Count == 0)
            {
                return BadRequest();
            }

            else
            {

                List<Corretora> listaCorretoras = new List<Corretora>();
                foreach (int corretora in updateCarteiraDTO.Corretoras)
                {
                    listaCorretoras.Add(await _context.Corretora.FindAsync(corretora));
                }

                List<Acao> listaAcoes = new List<Acao>();

                foreach (int itemAcao in updateCarteiraDTO.Acoes) {
                    
                    listaAcoes.Add(await _context.Acoes.FindAsync(itemAcao));
                }

                var newCarteira = new Carteira
                {
                    CarteiraId = updateCarteiraDTO.CarteiraId,
                    Nome = updateCarteiraDTO.Nome,
                    AcionistaId = updateCarteiraDTO.AcionistaId,
                    Acionista = acionista[0],
                    Acoes = listaAcoes,
                    Corretoras = listaCorretoras
                };

                _context.Carteiras.Update(newCarteira);
                await _context.SaveChangesAsync();

                return await Get(updateCarteiraDTO.CarteiraId);
            }  
        }

        [HttpGet("/VisualizarCarteira")]

        public async Task<ActionResult<List<Carteira>>> Get (int CarteiraId)
        {
            var carteiras = await _context.Carteiras
                .Where(x => x.CarteiraId == CarteiraId)
                .Include(x => x.Acionista)
                .Include(x => x.Acoes)
                .ToListAsync();

            return carteiras;
                
        }

        [HttpPost("/CriarCarteira")]
        public async Task<ActionResult<List<Carteira>>> Create(CreateCarteiraDTO createCarteiraDTO)
        {
            var acionista = await _context.Acionistas.FindAsync(createCarteiraDTO.AcionistaId);
            if(acionista == null)
            {
                return NotFound();
            }
            if(createCarteiraDTO.Acoes.Count != 0)
            {
                List<Acao> acaoLista = new List<Acao>();
                foreach (int acao in createCarteiraDTO.Acoes)
                {
                   acaoLista.Add( await _context.Acoes.FindAsync(acao) );
                }

                List<Corretora> corretorasLista = new List<Corretora>(); 
                foreach(int corretora in createCarteiraDTO.Corretoras)
                {
                    corretorasLista.Add(await _context.Corretora.FindAsync(corretora) );
                }

                var newCarteira = new Carteira
                {
                    Nome = createCarteiraDTO.Nome,
                    Acionista = acionista,
                    Acoes = acaoLista,
                    Corretoras = corretorasLista
                    
                };

                _context.Carteiras.Add(newCarteira);
                await _context.SaveChangesAsync();

                return await Get(newCarteira.CarteiraId);
            }
            else
            {
                return NotFound();
            }

          

        }

        [HttpDelete("/DeletarCarteira")]

        public async Task<ActionResult<List<Carteira>>> Delete(int CarteiraId)
        {
            var carteiraBusca = await _context.Carteiras
                 .Where(x => x.CarteiraId == CarteiraId)
                 .AsNoTracking()
                 .ToListAsync();

            if(carteiraBusca.Count != 0)
            {
                var acionistaBusca = await _context.Acionistas
                     .Where(x => x.AcionistaId == carteiraBusca[0].AcionistaId)
                     .AsNoTracking()
                     .ToListAsync();

                if(acionistaBusca.Count != 0)
                {
                    var acoesBusca = await _context.Acoes
                    .AsNoTracking()
                    .ToListAsync();

                    Carteira carteira = new Carteira();
                    carteira.CarteiraId = carteiraBusca[0].CarteiraId;
                    carteira.Nome = carteiraBusca[0].Nome;
                    carteira.Acionista = acionistaBusca[0];
                    carteira.AcionistaId = carteiraBusca[0].AcionistaId;
                    carteira.Acoes = acoesBusca;
                    _context.Carteiras.Remove(carteira);
                    _context.SaveChanges();
                    return NoContent();
                   

                    
                }

                else
                {
                    return NotFound();
                }
               
            }
            else
            {
                return NotFound();
            }
        }

    }
}
