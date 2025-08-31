using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Models
{
    public class RespuestaOpcion
    {
        public int RespuestaId { get; set; }
        public Respuesta Respuesta { get; set; }

        public int OpcionId { get; set; }
        public PreguntaOpcion Opcion { get; set; }
    }
}