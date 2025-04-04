using Microsoft.EntityFrameworkCore;

public class LibreriaDbContext : DbContext
{
    public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<ComentarioLibro> ComentariosLibros { get; set; }
    public DbSet<PedidoEncabezado> PedidosEncabezados { get; set; }
    public DbSet<PedidoDetalle> PedidosDetalles { get; set; }
}

