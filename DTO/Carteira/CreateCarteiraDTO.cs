using BolsaDeValores.Migrations;

namespace BolsaDeValores.DTO.Carteira
{
    public class CreateCarteiraDTO
    {
        public string Nome { get; set; }
        public int AcionistaId { get; set; }

        public List<int> Acoes { get; set; }

        public List<int> Corretoras { get; set; }
    }
}
