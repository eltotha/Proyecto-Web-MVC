using System.ComponentModel.DataAnnotations;

namespace GestorEncuestas_MVC.Models
{
    public class PreguntaOpcion
    {
        public int Id { get; set; }
        public int Position { get; set; }
        
        [Required]
        public string Label { get; set; } = string.Empty;
        
        [Required]
        public string Value { get; set; } = string.Empty;

        // FK
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; } = null!;

        // Relaciones
        public ICollection<Respuesta> Respuestas { get; set; } = new List<Respuesta>();
        public ICollection<RespuestaOpcion> RespuestasOpciones { get; set; } = new List<RespuestaOpcion>();
    }
}