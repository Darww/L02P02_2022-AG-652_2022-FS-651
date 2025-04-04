using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AutoresController : Controller
{
    private readonly LibreriaDbContext _context;

    public AutoresController(LibreriaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var autores = _context.Autores.ToList();
        return View(autores);
    }

    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(autor);
    }
}

