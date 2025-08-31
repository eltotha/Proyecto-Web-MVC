using GestorEncuestas_MVC.Models;
using System;

namespace GestorEncuestas_MVC.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime CierraEn { get; set; }
        public DateTime CreadoEn { get; set; }

        // FK
        public int AutorId { get; set; }
        public Usuario Autor { get; set; }

        // Relaciones
        public ICollection<Pregunta> Preguntas { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
    }
}