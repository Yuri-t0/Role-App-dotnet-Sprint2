using Microsoft.EntityFrameworkCore;
using Role.Domain.Entities;
using Role.Domain.Interfaces;
using Role.Infrastructure.Context;

namespace Role.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly RoleDbContext _ctx;
    public UsuarioRepository(RoleDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Usuario>> GetAllAsync()
        => await _ctx.Usuarios.AsNoTracking().ToListAsync();

    public async Task<Usuario?> GetByIdAsync(int id)
        => await _ctx.Usuarios.FindAsync(id);

    public async Task AddAsync(Usuario usuario)
    {
        _ctx.Usuarios.Add(usuario);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _ctx.Usuarios.Update(usuario);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Usuario usuario)
    {
        _ctx.Usuarios.Remove(usuario);
        await _ctx.SaveChangesAsync();
    }
}
