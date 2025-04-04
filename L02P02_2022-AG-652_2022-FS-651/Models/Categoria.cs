using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("categorias")]
public class Categoria
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("categoria")] 
    public string Nombre { get; set; }
}