namespace BolsaDeValores.DTO.Acao
{
    public class CreateAcaoDTO
    {
        public string NomeEmpresa { get; set; }
        public string Codigo { get; set; }
        public decimal Cotacao { get; set; }
        public int CarteiraId { get; set; }
    }
}
