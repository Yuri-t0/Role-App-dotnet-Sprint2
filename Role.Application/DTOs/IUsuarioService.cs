using Role.Application.DTOs;

namespace Role.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllAsync();
    Task<UsuarioDTO?> GetAsync(int id);
    Task<int> CreateAsync(UsuarioDTO dto);
    Task UpdateAsync(int id, UsuarioDTO dto);
    Task DeleteAsync(int id);
}
