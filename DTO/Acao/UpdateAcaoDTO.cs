using System.Text.Json.Serialization;

namespace BolsaDeValores.DTO.Acao
{
    public class UpdateAcaoDTO
    {
        public int AcaoId { get; set; }
        public string NomeEmpresa { get; set; }
        public string Codigo { get; set; }
        public decimal Cotacao { get; set; }
        public int CarteiraId { get; set; }
    }
}
