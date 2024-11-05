using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Aplicacao.ModuloCategoria;
using NoteKeeper.Dominio.ModuloCategoria;

namespace NoteKeeper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ServicoCategoria servicoCategoria;

        public CategoriaController(ServicoCategoria servicoCategoria)
        {
            this.servicoCategoria = servicoCategoria;
        }


        [HttpGet(Name = "GetCategtoria")]
        public async Task<IActionResult> Get()
        {
            var resultado = await servicoCategoria.SelecionarTodosAsync();

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resultado.Value);

        }
    }
}
