namespace Role.Domain.Entities;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public DateTime Data { get; set; }
    public string Local { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public int CriadorId { get; set; }
}
