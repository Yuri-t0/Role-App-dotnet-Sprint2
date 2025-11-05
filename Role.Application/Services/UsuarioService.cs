using Role.Application.DTOs;
using Role.Application.Interfaces;
using Role.Domain.Entities;
using Role.Domain.Interfaces;

namespace Role.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo) => _repo = repo;

    public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
    {
        var usuarios = await _repo.GetAllAsync();
        return usuarios.Select(u => new UsuarioDTO(u.Id, u.Nome, u.Email, u.Localizacao));
    }

    public async Task<UsuarioDTO?> GetAsync(int id)
    {
        var usuario = await _repo.GetByIdAsync(id);
        return usuario is null ? null : new UsuarioDTO(usuario.Id, usuario.Nome, usuario.Email, usuario.Localizacao);
    }

    public async Task<int> CreateAsync(UsuarioDTO dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Localizacao = dto.Localizacao
        };
        await _repo.AddAsync(usuario);
        return usuario.Id;
    }

    public async Task UpdateAsync(int id, UsuarioDTO dto)
    {
        var usuario = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Usuário não encontrado.");

        usuario.Nome = dto.Nome;
        usuario.Email = dto.Email;
        usuario.Localizacao = dto.Localizacao;

        await _repo.UpdateAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Usuário não encontrado.");
        await _repo.DeleteAsync(usuario);
    }
}
