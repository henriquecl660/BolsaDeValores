using System.Text.Json.Serialization;

namespace BolsaDeValores.Models
{
    public class Corretora
    {
        public int CorretoraId { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public char PossuiOutrasCorretoras { get; set; }

        [JsonIgnore]
        public List<Carteira> Carteiras { get; set; }
    }
}
