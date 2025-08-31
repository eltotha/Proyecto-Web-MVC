using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }

        // FK
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        // Relaciones
        public ICollection<Encuesta> EncuestasCreadas { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
    }
}