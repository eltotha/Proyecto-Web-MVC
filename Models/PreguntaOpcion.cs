using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Models
{
    public class PreguntaOpcion
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }

        // FK
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }

        // Relaciones
        public ICollection<Respuesta> Respuestas { get; set; }
        public ICollection<RespuestaOpcion> RespuestasOpciones { get; set; }
    }
}