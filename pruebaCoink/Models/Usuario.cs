namespace pruebaCoink.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El ID del país es obligatorio.")]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El ID del departamento es obligatorio.")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "El ID del municipio es obligatorio.")]
        public int MunicipioId { get; set; }
    }


}
