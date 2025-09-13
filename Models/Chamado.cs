namespace ApiServico.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }  
        public required string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string Status { get; set; } = "Aberto";
    }
}
