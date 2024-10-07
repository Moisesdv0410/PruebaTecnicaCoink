using pruebaCoink.Interfaces;
using pruebaCoink.Models;

namespace pruebaCoink.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CrearUsuario(Usuario usuario)
        {
            // validación antes de registrar el usuario
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            _usuarioRepository.CrearUsuario(usuario);
        }
    }

}
