using Microsoft.EntityFrameworkCore;
using GestorEncuestas_MVC.Models;
namespace GestorEncuestas_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<PreguntaOpcion> PreguntasOpciones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<RespuestaOpcion> RespuestasOpciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la tabla intermedia RespuestaOpcion (N:M)
            modelBuilder.Entity<RespuestaOpcion>()
                .HasKey(ro => new { ro.RespuestaId, ro.OpcionId });

            modelBuilder.Entity<RespuestaOpcion>()
                .HasOne(ro => ro.Respuesta)
                .WithMany(r => r.RespuestasOpciones)
                .HasForeignKey(ro => ro.RespuestaId);

            modelBuilder.Entity<RespuestaOpcion>()
                .HasOne(ro => ro.Opcion)
                .WithMany(o => o.RespuestasOpciones)
                .HasForeignKey(ro => ro.OpcionId);
        }
    }
}