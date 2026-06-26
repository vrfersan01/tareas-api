using System.ComponentModel.DataAnnotations;

namespace tareas_api.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(150)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
