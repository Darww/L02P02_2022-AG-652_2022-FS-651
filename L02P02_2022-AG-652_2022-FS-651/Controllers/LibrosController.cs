using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class LibrosController : Controller
{
    private readonly LibreriaDbContext _context;

    public LibrosController(LibreriaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        try
        {
            var libros = _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .ToList();

            return View(libros);
        }
        catch (Exception ex)
        {
            // Log del error
            Console.WriteLine($"Error al cargar libros: {ex.Message}");
            return View(new List<Libro>());
        }
    }


    public IActionResult Crear()
    {
        ViewBag.Autores = new SelectList(_context.Autores, "Id", "Nombre");
        ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre");
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Libro libro)
    {
        if (ModelState.IsValid)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(libro);
    }

    public IActionResult Editar(int id)
    {
        var libro = _context.Libros.Find(id);
        if (libro == null) return NotFound();

        ViewBag.Autores = new SelectList(_context.Autores, "Id", "Nombre", libro.IdAutor);
        ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nombre", libro.IdCategoria);
        return View(libro);
    }

    [HttpPost]
    public IActionResult Editar(Libro libro)
    {
        if (ModelState.IsValid)
        {
            _context.Libros.Update(libro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(libro);
    }

    public IActionResult Eliminar(int id)
    {
        var libro = _context.Libros.Find(id);
        if (libro == null) return NotFound();

        _context.Libros.Remove(libro);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

