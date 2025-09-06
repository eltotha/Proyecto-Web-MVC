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

            // Configurar nombres de tablas
            modelBuilder.Entity<Encuesta>().ToTable("encuestas");
            modelBuilder.Entity<Pregunta>().ToTable("preguntas");
            modelBuilder.Entity<PreguntaOpcion>().ToTable("preguntas_opciones");
            modelBuilder.Entity<Respuesta>().ToTable("respuestas");
            modelBuilder.Entity<RespuestaOpcion>().ToTable("respuestas_opciones");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Rol>().ToTable("roles");

            // Configurar mapeo de columnas para Encuesta
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.AutorId)
                .HasColumnName("autor");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.Titulo)
                .HasColumnName("titulo");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.Descripcion)
                .HasColumnName("descripcion");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.Estado)
                .HasColumnName("estado");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.CierraEn)
                .HasColumnName("cierra_en");
                
            modelBuilder.Entity<Encuesta>()
                .Property(e => e.CreadoEn)
                .HasColumnName("creado_en");

            // Configurar mapeo de columnas para Pregunta
            modelBuilder.Entity<Pregunta>()
                .Property(p => p.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<Pregunta>()
                .Property(p => p.EncuestaId)
                .HasColumnName("encuesta_id");
                
            modelBuilder.Entity<Pregunta>()
                .Property(p => p.Enunciado)
                .HasColumnName("enunciado");
                
            modelBuilder.Entity<Pregunta>()
                .Property(p => p.TipoPregunta)
                .HasColumnName("tipo_pregunta");
                
            modelBuilder.Entity<Pregunta>()
                .Property(p => p.Obligatorio)
                .HasColumnName("obligatorio");

            // Configurar mapeo de columnas para PreguntaOpcion
            modelBuilder.Entity<PreguntaOpcion>()
                .Property(po => po.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<PreguntaOpcion>()
                .Property(po => po.PreguntaId)
                .HasColumnName("pregunta_id");
                
            modelBuilder.Entity<PreguntaOpcion>()
                .Property(po => po.Position)
                .HasColumnName("position");
                
            modelBuilder.Entity<PreguntaOpcion>()
                .Property(po => po.Label)
                .HasColumnName("Label");
                
            modelBuilder.Entity<PreguntaOpcion>()
                .Property(po => po.Value)
                .HasColumnName("Value");

            // Configurar mapeo de columnas para Respuesta
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.UsuarioId)
                .HasColumnName("usuario_respuesta");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.EncuestaId)
                .HasColumnName("encuesta_id");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.PreguntaId)
                .HasColumnName("pregunta_id");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.Texto)
                .HasColumnName("respuesta");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.Numerica)
                .HasColumnName("respuesta_numeros");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.FechaRespuesta)
                .HasColumnName("fecha_respuesta");
                
            modelBuilder.Entity<Respuesta>()
                .Property(r => r.SeleccionOpcionId)
                .HasColumnName("seleccion_opcion_id");

            // Configurar mapeo de columnas para RespuestaOpcion
            modelBuilder.Entity<RespuestaOpcion>()
                .Property(ro => ro.RespuestaId)
                .HasColumnName("respuesta_id");
                
            modelBuilder.Entity<RespuestaOpcion>()
                .Property(ro => ro.OpcionId)
                .HasColumnName("opcion");

            // Configurar mapeo de columnas para Usuario
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Username)
                .HasColumnName("username");
                
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Passwd)
                .HasColumnName("passwd");
                
            modelBuilder.Entity<Usuario>()
                .Property(u => u.RolId)
                .HasColumnName("rol");

            // Configurar mapeo de columnas para Rol
            modelBuilder.Entity<Rol>()
                .Property(r => r.Id)
                .HasColumnName("id");
                
            modelBuilder.Entity<Rol>()
                .Property(r => r.RolNombre)
                .HasColumnName("rol");

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

            // Configurar relaciones adicionales si es necesario
            modelBuilder.Entity<Encuesta>()
                .HasOne(e => e.Autor)
                .WithMany(u => u.EncuestasCreadas)
                .HasForeignKey(e => e.AutorId);

            modelBuilder.Entity<Pregunta>()
                .HasOne(p => p.Encuesta)
                .WithMany(e => e.Preguntas)
                .HasForeignKey(p => p.EncuestaId);

            modelBuilder.Entity<PreguntaOpcion>()
                .HasOne(po => po.Pregunta)
                .WithMany(p => p.Opciones)
                .HasForeignKey(po => po.PreguntaId);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Respuestas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Encuesta)
                .WithMany(e => e.Respuestas)
                .HasForeignKey(r => r.EncuestaId);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Pregunta)
                .WithMany(p => p.Respuestas)
                .HasForeignKey(r => r.PreguntaId);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.SeleccionOpcion)
                .WithMany(po => po.Respuestas)
                .HasForeignKey(r => r.SeleccionOpcionId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);
        }
    }
}