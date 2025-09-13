using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServico.Models.Dtos;
using ApiServico.Models;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {

        private static List<Chamado> ListaChamados = new List<Chamado>
        {
            new Chamado() {Id = 1, Titulo = "Erro na Tela de Acesso",
            Descricao = "O usuário não conseguiu logar"},
            new Chamado() {Id = 2, Titulo = "Sistema com lentidão",
            Descricao = "Demora no carregamento das telas"}
        };

        private static int proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(ListaChamados);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            var chamado = ListaChamados.FirstOrDefault(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ChamadoDto novoChamado)
        {
            var chamado = new Chamado() { Titulo = novoChamado.Titulo, Descricao = novoChamado.Descricao};
            chamado.Id = proximoId++;
            chamado.Status = "Aberto";

            ListaChamados.Add(chamado);

            return Created("", chamado);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] ChamadoDto novoChamado)
        {
            var chamado = ListaChamados.FirstOrDefault(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            chamado.Titulo = novoChamado.Titulo;
            chamado.Descricao = novoChamado.Descricao;

            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var chamado = ListaChamados.FirstOrDefault(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            ListaChamados.Remove(chamado);

            return NoContent();
        }

        [HttpPut("{id}/fecharStatus")]
        public IActionResult Fechar(int id)
        {
            var chamado = ListaChamados.FirstOrDefault(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            chamado.Status = "Fechado";
            chamado.DataFechamento = DateTime.Now;

            return Ok(chamado);
        }

    }
}
