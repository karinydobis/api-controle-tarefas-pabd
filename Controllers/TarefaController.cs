using ApiServico.Models;
using ApiServico.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private static List<Tarefa> ListaTarefas = new List<Tarefa>
        {
            new Tarefa() {Id = 1, descricao = "Tarefa de Nº 1",
            dataAbertura = DateTime.Now, situacao = "Aberto"},
            new Tarefa() {Id = 2, descricao = "Tarefa de Nº 2",
            dataAbertura = DateTime.Now, situacao = "Aberto"}
        };

        private static int proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(ListaTarefas);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            var tarefa = ListaTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TarefaDto novaTarefa)
        {
            var tarefa = new Tarefa() { descricao = novaTarefa.descricao};
            tarefa.Id = proximoId++;
            tarefa.situacao = "Aberto";
            tarefa.dataAbertura = DateTime.Now;

            ListaTarefas.Add(tarefa);

            return Created("", tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] TarefaDto novaTarefa)
        {
            var tarefa = ListaTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa is null)
            {
                return NotFound();
            }

            tarefa.descricao = novaTarefa.descricao;

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var tarefa = ListaTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa is null)
            {
                return NotFound();
            }

            ListaTarefas.Remove(tarefa);

            return NoContent();
        }

        [HttpPut("{id}/fecharStatus")]
        public IActionResult Fechar(int id)
        {
            var tarefa = ListaTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa is null)
            {
                return NotFound();
            }

            tarefa.situacao = "Fechado";
            tarefa.dataFechamento = DateTime.Now;

            return Ok(tarefa);
        }
    }
}
