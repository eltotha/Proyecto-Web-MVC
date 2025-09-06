using System.ComponentModel.DataAnnotations;

namespace GestorEncuestas_MVC.Models
{
    public class RespuestaOpcion
    {
        public int RespuestaId { get; set; }
        public Respuesta Respuesta { get; set; } = null!;

        public int OpcionId { get; set; }
        public PreguntaOpcion Opcion { get; set; } = null!;
    }
}