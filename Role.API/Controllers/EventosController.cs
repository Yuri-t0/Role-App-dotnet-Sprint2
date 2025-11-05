using Microsoft.AspNetCore.Mvc;
using Role.Application.DTOs;
using Role.Application.Interfaces;

namespace Role.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventoService _service;

    public EventosController(IEventoService service) => _service = service;

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string? nome,
        [FromQuery] string? local,
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanho = 5,
        [FromQuery] string? ordem = "data")
    {
        var eventos = await _service.SearchAsync(nome, local, pagina, tamanho, ordem);
        var total = eventos.Count();
        var response = new
        {
            total,
            links = new
            {
                self = Url.Action(nameof(Search), new { nome, local, pagina, tamanho }),
                next = total == tamanho ? Url.Action(nameof(Search), new { nome, local, pagina = pagina + 1, tamanho }) : null,
                prev = pagina > 1 ? Url.Action(nameof(Search), new { nome, local, pagina = pagina - 1, tamanho }) : null
            },
            data = eventos
        };
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var evento = await _service.GetAsync(id);
        if (evento is null) return NotFound();
        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventoDTO dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EventoDTO dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
