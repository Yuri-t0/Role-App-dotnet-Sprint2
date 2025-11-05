using Role.Application.DTOs;

namespace Role.Application.Interfaces;

public interface IEventoService
{
    Task<IEnumerable<EventoDTO>> GetAllAsync();
    Task<EventoDTO?> GetAsync(int id);
    Task<int> CreateAsync(EventoDTO dto);
    Task UpdateAsync(int id, EventoDTO dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<EventoDTO>> SearchAsync(string? nome, string? local, int pagina, int tamanho, string? ordem);
}
