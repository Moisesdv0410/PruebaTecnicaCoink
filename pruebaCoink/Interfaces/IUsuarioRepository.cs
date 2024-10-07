using pruebaCoink.Models;

namespace pruebaCoink.Interfaces
{
    public interface IUsuarioRepository
    {
        void CrearUsuario(Usuario usuario);
        bool ValidarPais(int paisId);
        bool ValidarDepartamento(int departamentoId);
        bool ValidarMunicipio(int municipioId);
    }
}
