using System.Text.Json.Serialization;

namespace BolsaDeValores.Models
{
    public class Acao
    {
        public int AcaoId { get; set; }
        public string NomeEmpresa { get; set; }
        public string Codigo { get; set; }
        public decimal Cotacao { get; set; }
        public int CarteiraId { get; set; }
        [JsonIgnore]
        public Carteira Carteira { get; set; }
    }
}
