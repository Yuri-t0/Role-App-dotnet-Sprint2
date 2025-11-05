using Microsoft.EntityFrameworkCore;
using Role.Domain.Entities;

namespace Role.Infrastructure.Context;

public class RoleDbContext : DbContext
{
    public RoleDbContext(DbContextOptions<RoleDbContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Evento> Eventos => Set<Evento>();
    public DbSet<Presenca> Presencas => Set<Presenca>();
}
