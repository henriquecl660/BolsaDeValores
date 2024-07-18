using BolsaDeValores.Data;
using BolsaDeValores.DTO.Acao;
using BolsaDeValores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeValores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoController : ControllerBase
    {

        public readonly DataContext _context;

        public AcaoController(DataContext context)
        {
            _context = context;
        }

        [HttpPut("/AlterarAcao")]
        
        public async Task<ActionResult<List<Acao>>> Put (UpdateAcaoDTO updateAcaoDTO)
        {
            var carteira = await _context.Carteiras
                .Where(x => x.CarteiraId == updateAcaoDTO.CarteiraId)
                .ToListAsync();

            if(carteira.Count != 0)
            {
                Acao newAcao = new Acao();
                newAcao.AcaoId = updateAcaoDTO.AcaoId;
                newAcao.NomeEmpresa = updateAcaoDTO.NomeEmpresa;
                newAcao.Codigo = updateAcaoDTO.Codigo;
                newAcao.Cotacao = updateAcaoDTO.Cotacao;
                newAcao.CarteiraId = updateAcaoDTO.CarteiraId;
                newAcao.Carteira = carteira.FirstOrDefault();

                _context.Acoes.Update(newAcao);
                _context.SaveChanges();
                return await Get(updateAcaoDTO.AcaoId);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("/ExcluirAcao")]
        
        public async Task<ActionResult<List<Acao>>> Delete (int AcaoId)
        {
            var acoes = await _context.Acoes
                .Where(x => x.AcaoId == AcaoId)
                .AsNoTracking()
                .ToListAsync();

            if (acoes.Count == 0)
            {
                return NotFound();
            }

            else
            {
                var carteira = await _context.Carteiras
                    .Where(x => x.CarteiraId == acoes.FirstOrDefault().CarteiraId)
                    .AsNoTracking()
                    .ToListAsync();

               if(carteira.Count !=0)
                {
                    Acao acao = new Acao();
                    acao.AcaoId = AcaoId;
                    acao.NomeEmpresa = acoes[0].NomeEmpresa;
                    acao.Codigo = acoes[0].Codigo;
                    acao.Cotacao = acoes[0].Cotacao;
                    acao.CarteiraId = acoes[0].CarteiraId;
                    acao.Carteira = carteira[0];

                    _context.Acoes.Remove(acao);
                    _context.SaveChanges();

                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet("/VisualizarAcao")]
        public async Task<ActionResult<List<Acao>>> Get (int AcaoId)
        {
            var acoes = await _context.Acoes
                .Where(x => x.AcaoId == AcaoId)
                .Include(x => x.Carteira)
                .ToListAsync();

            return acoes;
        }

        [HttpPost("/CriarAcao")]
        public async Task<ActionResult<List<Acao>>> Create(CreateAcaoDTO createAcaoDTO)
        {
            var carteira = await _context.Carteiras.FindAsync(createAcaoDTO.CarteiraId);
            if(carteira == null)
            {
                return NotFound();
            }

            var newAcao = new Acao
            {
                NomeEmpresa = createAcaoDTO.NomeEmpresa,
                Codigo = createAcaoDTO.Codigo,
                Cotacao = createAcaoDTO.Cotacao,
                CarteiraId = createAcaoDTO.CarteiraId,
                Carteira = carteira
               
            };

            _context.Acoes.Add(newAcao);
            _context.SaveChanges(); 
            return await Get(newAcao.AcaoId);
        }

    }
}
