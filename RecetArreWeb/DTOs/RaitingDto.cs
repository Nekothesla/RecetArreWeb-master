using System.ComponentModel.DataAnnotations;

namespace RecetArreWeb.DTOs
{
    public class RaitingDto
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; }
        public int RecetaId { get; set; }
        public string UsuarioId { get; set; } = default!;
        public string? NombreUsuario { get; set; }
        public DateTime CreadoUtc { get; set; }
        public DateTime ModificadoUtc { get; set; }
    }

    public class RaitingCreacionDto
    {
        [Required(ErrorMessage = "El Id de la receta es obligatorio.")]
        public int RecetaId { get; set; }

        [Required(ErrorMessage = "La puntuación es obligatoria.")]
        [Range(1, 5, ErrorMessage = "La puntuación debe ser entre 1 y 5 medallas.")]
        public int Puntuacion { get; set; }
    }

    public class RaitingModificacionDto
    {
        [Required(ErrorMessage = "La puntuación es obligatoria.")]
        [Range(1, 5, ErrorMessage = "La puntuación debe ser entre 1 y 5 medallas.")]
        public int Puntuacion { get; set; }
    }

    public class RaitingResumenDto
    {
        public int RecetaId { get; set; }
        public double PromedioMedallas { get; set; }
        public int TotalVotos { get; set; }
        public Dictionary<int, int> DistribucionMedallas { get; set; } = new();
    }
}
