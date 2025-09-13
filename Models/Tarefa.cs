namespace ApiServico.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string descricao { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataFechamento { get; set; }
        public string situacao { get; set; }

    }
}
