using System.ComponentModel.DataAnnotations.Schema;

public class Libro
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("descripcion")]
    public string Descripcion { get; set; }

    [Column("url_imagen")]
    public string UrlImagen { get; set; }

    [Column("id_autor")]
    public int IdAutor { get; set; }

    [Column("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("precio")]
    public decimal Precio { get; set; }

    [Column("estado")]
    public char Estado { get; set; }

    [ForeignKey("IdAutor")]
    public virtual Autor Autor { get; set; }

    [ForeignKey("IdCategoria")]
    public virtual Categoria Categoria { get; set; }
}