using System.ComponentModel.DataAnnotations;

namespace Leodanny_maria_mercedes_P1_AP1.Models
{
    public class reportes
    {
        [Key]
        public int ReporteId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal Monto { get; set; }

        [MaxLength(500, ErrorMessage = "La observación no puede exceder los 500 caracteres.")]
        public string Observacion { get; set; }

        [Required(ErrorMessage = "El nombre de la persona es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la persona no puede exceder los 100 caracteres.")]
        public string Persona { get; set; }
    }
}