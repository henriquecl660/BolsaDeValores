namespace BolsaDeValores.DTO.Carteira
{
    public class UpdateCarteiraDTO
    {
        public int CarteiraId { get; set; }
        public string Nome { get; set; }
        public int AcionistaId { get; set; }

        public List<int> Acoes { get; set; }   
        public List<int> Corretoras { get; set; }   
    }
}
