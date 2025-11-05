using Microsoft.AspNetCore.Mvc;
using Role.Application.DTOs;
using Role.Application.Interfaces;

namespace Role.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _service.GetAllAsync();
        var response = usuarios.Select(u => new
        {
            u.Id,
            u.Nome,
            u.Email,
            u.Localizacao,
            links = new[]
            {
                new { rel = "self", href = Url.Action(nameof(GetById), new { id = u.Id }) },
                new { rel = "update", href = Url.Action(nameof(Update), new { id = u.Id }) },
                new { rel = "delete", href = Url.Action(nameof(Delete), new { id = u.Id }) }
            }
        });
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _service.GetAsync(id);
        if (usuario is null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDTO dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO dto)
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
