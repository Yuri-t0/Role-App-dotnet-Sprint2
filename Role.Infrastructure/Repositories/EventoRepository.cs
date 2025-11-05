using Microsoft.EntityFrameworkCore;
using Role.Domain.Entities;
using Role.Domain.Interfaces;
using Role.Infrastructure.Context;

namespace Role.Infrastructure.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly RoleDbContext _ctx;
    public EventoRepository(RoleDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Evento>> GetAllAsync()
        => await _ctx.Eventos.AsNoTracking().ToListAsync();

    public async Task<Evento?> GetByIdAsync(int id)
        => await _ctx.Eventos.FindAsync(id);

    public async Task AddAsync(Evento evento)
    {
        _ctx.Eventos.Add(evento);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Evento evento)
    {
        _ctx.Eventos.Update(evento);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Evento evento)
    {
        _ctx.Eventos.Remove(evento);
        await _ctx.SaveChangesAsync();
    }
}
