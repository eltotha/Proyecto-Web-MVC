using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string RolNombre { get; set; }

        // Relación 1:N con Usuarios
        public ICollection<Usuario> Usuarios { get; set; }
    }
}