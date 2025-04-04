using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics; // Para el logging

public class ComentariosController : Controller
{
    private readonly LibreriaDbContext _context;
    private readonly ILogger<ComentariosController> _logger;

    // Inyectamos el logger además del contexto
    public ComentariosController(LibreriaDbContext context, ILogger<ComentariosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> PorLibro(int idLibro)
    {
        try
        {
            var libro = await _context.Libros
                .Include(l => l.Autor)
                .AsNoTracking() // Mejor rendimiento para solo lectura
                .FirstOrDefaultAsync(l => l.Id == idLibro);

            if (libro == null)
            {
                _logger.LogWarning($"Libro con ID {idLibro} no encontrado");
                return NotFound();
            }

            var comentarios = await _context.ComentariosLibros
                .Where(c => c.IdLibro == idLibro)
                .OrderByDescending(c => c.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Libro = libro;
            return View(comentarios);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cargar comentarios por libro");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken] // Protección contra CSRF
    public async Task<IActionResult> AgregarComentario(int idLibro, string texto, string usuario)
    {
        try
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(texto))
            {
                TempData["Error"] = "El comentario no puede estar vacío";
                return RedirectToAction("PorLibro", new { idLibro });
            }

            // Verificar que el libro existe
            if (!await _context.Libros.AnyAsync(l => l.Id == idLibro))
            {
                return NotFound();
            }

            var nuevoComentario = new ComentarioLibro
            {
                IdLibro = idLibro,
                Comentarios = texto, // Nota: Propiedad debe coincidir con tu modelo
                Usuario = usuario ?? "Anónimo",
                CreatedAt = DateTime.Now
            };

            _context.ComentariosLibros.Add(nuevoComentario);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Comentario agregado exitosamente";
            return RedirectToAction("Confirmacion", new { id = nuevoComentario.Id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar comentario");
            TempData["Error"] = "Ocurrió un error al guardar el comentario";
            return RedirectToAction("PorLibro", new { idLibro });
        }
    }

    public async Task<IActionResult> Confirmacion(int id)
    {
        try
        {
            var comentario = await _context.ComentariosLibros
                .Include(c => c.Libro)
                .ThenInclude(l => l.Autor)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cargar confirmación de comentario");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}