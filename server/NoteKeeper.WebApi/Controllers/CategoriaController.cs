using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Aplicacao.ModuloCategoria;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.WebApi.Views;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapeador;

    public CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeador)
    {
        this.servicoCategoria = servicoCategoria;
        this.mapeador = mapeador;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var resultado = await servicoCategoria.SelecionarTodosAsync();

        if (resultado.IsFailed)
            return StatusCode(500);

        return Ok(resultado.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InserirCategoriaViewModel categoriaVm)
    {
        var categoria = mapeador.Map<Categoria>(categoriaVm);

        var resultado = await servicoCategoria.InserirAsync(categoria);

        if (resultado.IsFailed)
            return BadRequest(resultado.Errors);

        return Ok(categoriaVm);
    }
}
