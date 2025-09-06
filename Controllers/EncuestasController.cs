using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorEncuestas_MVC.Data;
using GestorEncuestas_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEncuestas_MVC.Controllers
{
    public class EncuestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncuestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Encuestas
        public async Task<IActionResult> Index()
        {
            var encuestas = await _context.Encuestas
                .Include(e => e.Autor)
                .ToListAsync();
            return View(encuestas);
        }

        // GET: Encuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .Include(e => e.Autor)
                .Include(e => e.Preguntas)
                    .ThenInclude(p => p.Opciones)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encuestas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descripcion,Estado,CierraEn")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                encuesta.CreadoEn = DateTime.Now;
                // En un sistema real, aquí se asignaría el usuario autenticado
                encuesta.AutorId = 1; // Valor temporal para pruebas
                
                _context.Add(encuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Estado,CierraEn,CreadoEn,AutorId")] Encuesta encuesta)
        {
            if (id != encuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuestaExists(encuesta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .Include(e => e.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encuesta = await _context.Encuestas.FindAsync(id);
            _context.Encuestas.Remove(encuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Encuestas/CreatePregunta/5
        public async Task<IActionResult> CreatePregunta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }

            ViewData["EncuestaId"] = id.Value;
            ViewData["EncuestaTitulo"] = encuesta.Titulo;
            return View();
        }

        // POST: Encuestas/CreatePregunta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePregunta(int encuestaId, [Bind("Enunciado,TipoPregunta,Obligatorio")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                pregunta.EncuestaId = encuestaId;
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = encuestaId });
            }
            
            var encuesta = await _context.Encuestas.FindAsync(encuestaId);
            ViewData["EncuestaId"] = encuestaId;
            ViewData["EncuestaTitulo"] = encuesta.Titulo;
            return View(pregunta);
        }

        private bool EncuestaExists(int id)
        {
            return _context.Encuestas.Any(e => e.Id == id);
        }
    }
}