namespace BolsaDeValores.DTO.Corretora
{
    public class CreateCorretoraDTO
    {
        public int CorretoraId { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public char PossuiOutrasCorretoras { get; set; }

        public List<int> Carteiras { get; set; }
    }
}
