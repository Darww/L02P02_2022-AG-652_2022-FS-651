public class Libro
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string UrlImagen { get; set; }
    public int IdAutor { get; set; }
    public Autor Autor { get; set; }
    public int IdCategoria { get; set; }
    public Categoria Categoria { get; set; }
    public decimal Precio { get; set; }
    public char Estado { get; set; }
}

