using Role.Application.DTOs;
using Role.Application.Interfaces;
using Role.Domain.Entities;
using Role.Domain.Interfaces;

namespace Role.Application.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repo;

    public EventoService(IEventoRepository repo) => _repo = repo;

    public async Task<IEnumerable<EventoDTO>> GetAllAsync()
    {
        var eventos = await _repo.GetAllAsync();
        return eventos.Select(e => new EventoDTO(e.Id, e.Nome, e.Data, e.Local, e.Latitude, e.Longitude, e.CriadorId));
    }

    public async Task<EventoDTO?> GetAsync(int id)
    {
        var evento = await _repo.GetByIdAsync(id);
        return evento is null ? null : new EventoDTO(evento.Id, evento.Nome, evento.Data, evento.Local, evento.Latitude, evento.Longitude, evento.CriadorId);
    }

    public async Task<int> CreateAsync(EventoDTO dto)
    {
        var evento = new Evento
        {
            Nome = dto.Nome,
            Data = dto.Data,
            Local = dto.Local,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            CriadorId = dto.CriadorId
        };
        await _repo.AddAsync(evento);
        return evento.Id;
    }

    public async Task UpdateAsync(int id, EventoDTO dto)
    {
        var evento = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Evento não encontrado.");

        evento.Nome = dto.Nome;
        evento.Data = dto.Data;
        evento.Local = dto.Local;
        evento.Latitude = dto.Latitude;
        evento.Longitude = dto.Longitude;

        await _repo.UpdateAsync(evento);
    }

    public async Task DeleteAsync(int id)
    {
        var evento = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Evento não encontrado.");
        await _repo.DeleteAsync(evento);
    }

    public async Task<IEnumerable<EventoDTO>> SearchAsync(string? nome, string? local, int pagina, int tamanho, string? ordem)
    {
        var eventos = await _repo.GetAllAsync();
        var query = eventos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
            query = query.Where(e => e.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(local))
            query = query.Where(e => e.Local.Contains(local, StringComparison.OrdinalIgnoreCase));

        query = ordem?.ToLower() switch
        {
            "nome" => query.OrderBy(e => e.Nome),
            "local" => query.OrderBy(e => e.Local),
            _ => query.OrderBy(e => e.Data)
        };

        var skip = (pagina - 1) * tamanho;
        query = query.Skip(skip).Take(tamanho);

        return query.Select(e => new EventoDTO(e.Id, e.Nome, e.Data, e.Local, e.Latitude, e.Longitude, e.CriadorId)).ToList();
    }
}
