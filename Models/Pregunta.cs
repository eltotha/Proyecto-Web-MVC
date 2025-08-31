using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string TipoPregunta { get; set; }
        public bool Obligatorio { get; set; }

        // FK
        public int EncuestaId { get; set; }
        public Encuesta Encuesta { get; set; }

        // Relaciones
        public ICollection<PreguntaOpcion> Opciones { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
    }
}