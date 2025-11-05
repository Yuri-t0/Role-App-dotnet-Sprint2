// Projeto: Rolê
// Autores: Adão Yuri Ferreira da Silva (RM 559223), João Vitor Lopes Santana (RM 560781)
// Disciplina: Advanced Business Development with .NET - FIAP 2025

using Microsoft.EntityFrameworkCore;
using Role.Application.Interfaces;
using Role.Application.Services;
using Role.Domain.Interfaces;
using Role.Infrastructure.Context;
using Role.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco InMemory (para teste e entrega)
builder.Services.AddDbContext<RoleDbContext>(options =>
    options.UseInMemoryDatabase("RoleDb"));

// Injeção de dependências
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEventoService, EventoService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
