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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.ToTable("autores");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("autor"); // Mapeo explícito
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("categorias");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("categoria"); // Mapeo explícito
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("libros");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.UrlImagen).HasColumnName("url_imagen");
            entity.Property(e => e.IdAutor).HasColumnName("id_autor");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });


    }
}

