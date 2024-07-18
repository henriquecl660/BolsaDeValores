using System.Text.Json.Serialization;

namespace BolsaDeValores.Models
{
    public class Carteira
    {
        public int CarteiraId { get; set; }
        public string Nome { get; set; }

        public int AcionistaId { get; set; }

        [JsonIgnore]
        public Acionista Acionista { get; set; }

        public List<Acao> Acoes { get; set; }

        public List<Corretora> Corretoras { get; set; }

    }
}
