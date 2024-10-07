using Npgsql;
using pruebaCoink.Interfaces;
using pruebaCoink.Models;
using System;
using System.Data;

namespace pruebaCoink.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void CrearUsuario(Usuario usuario)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("sp_insertarusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Nombres de los parámetros según el procedimiento almacenado
                    command.Parameters.AddWithValue("p_nombre_usuario", usuario.Nombre);
                    command.Parameters.AddWithValue("p_telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("p_direccion", usuario.Direccion);
                    command.Parameters.AddWithValue("p_id_pais", usuario.PaisId);
                    command.Parameters.AddWithValue("p_id_departamento", usuario.DepartamentoId);
                    command.Parameters.AddWithValue("p_id_municipio", usuario.MunicipioId);

                    // Ejecuta el Stored Procedure
                    command.ExecuteNonQuery();
                }

            }
        }

        // Los métodos de validación
        public bool ValidarDepartamento(int departamentoId) => throw new NotImplementedException();
        public bool ValidarMunicipio(int municipioId) => throw new NotImplementedException();
        public bool ValidarPais(int paisId) => throw new NotImplementedException();
    }
}
