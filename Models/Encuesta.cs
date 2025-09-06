using System.ComponentModel.DataAnnotations;

namespace GestorEncuestas_MVC.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        
        [Required]
        public string Titulo { get; set; } = string.Empty;
        
        public string Descripcion { get; set; } = string.Empty;
        
        [Required]
        public string Estado { get; set; } = string.Empty;
        
        public DateTime CierraEn { get; set; }
        public DateTime CreadoEn { get; set; }

        // FK
        public int AutorId { get; set; }
        public Usuario Autor { get; set; } = null!;

        // Relaciones
        public ICollection<Pregunta> Preguntas { get; set; } = new List<Pregunta>();
        public ICollection<Respuesta> Respuestas { get; set; } = new List<Respuesta>();
    }
}