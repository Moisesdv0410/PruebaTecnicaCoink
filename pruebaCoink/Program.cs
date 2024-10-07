using pruebaCoink.Interfaces;
using pruebaCoink.Repositories;
using pruebaCoink.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//controladores
builder.Services.AddControllers();

// Swagger para la documentaci�n
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
