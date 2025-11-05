using System.ComponentModel.DataAnnotations;

namespace Role.Application.DTOs;

public record EventoDTO(
    int Id,
    [Required, StringLength(160)] string Nome,
    [Required] DateTime Data,
    [Required, StringLength(200)] string Local,
    double Latitude,
    double Longitude,
    int CriadorId);
