using System.ComponentModel.DataAnnotations;

namespace RecetArreWeb.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Descripcion { get; set; }
        public DateTime CreadoUtc { get; set; }
    }

    public class CategoriaCreacionDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public string Nombre { get; set; } = default!;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }
    }

    public class CategoriaModificacionDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public string Nombre { get; set; } = default!;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }
    }

    public class IngredienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Notas { get; set; }
        public DateTime CreadoUtc { get; set; }
    }

    public class IngredienteCreacionDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public string Nombre { get; set; } = default!;

        [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
        public string? Notas { get; set; }
    }

    public class IngredienteModificacionDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres")]
        public string Nombre { get; set; } = default!;

        [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
        public string? Notas { get; set; }
    }
}
