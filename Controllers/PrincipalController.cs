using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        [HttpGet]
        public IActionResult Principal() 
        {
            var resultado = new { situacao = "Ok", mensagem = "API Serviço" };
            return Ok(resultado);
        }

        [HttpGet("/Autor")]
        public IActionResult Get()
        {
            var dados = new { nome = "Kariny de Almeida Dobis", 
                telefone = "(69) 9.9369-8628", 
                email = "dobiskariny@gmail.com" };

            return Ok(dados);
        }

    }


}
