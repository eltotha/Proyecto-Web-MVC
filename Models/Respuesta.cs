using System;
using GestorEncuestas_MVC.Models;

namespace GestorEncuestas_MVC.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public float? Numerica { get; set; }
        public DateTime FechaRespuesta { get; set; }

        // FK
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int EncuestaId { get; set; }
        public Encuesta Encuesta { get; set; }

        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }

        public int? SeleccionOpcionId { get; set; }
        public PreguntaOpcion SeleccionOpcion { get; set; }

        // Relaciones N:M
        public ICollection<RespuestaOpcion> RespuestasOpciones { get; set; }
    }
}