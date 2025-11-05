using System.ComponentModel.DataAnnotations;

namespace Role.Application.DTOs;

public record UsuarioDTO(
    int Id,
    [Required, StringLength(120)] string Nome,
    [Required, EmailAddress] string Email,
    [StringLength(100)] string? Localizacao);
