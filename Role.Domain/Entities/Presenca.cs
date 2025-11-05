namespace Role.Domain.Entities;

public class Presenca
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int EventoId { get; set; }
    public bool Confirmado { get; set; }
}
