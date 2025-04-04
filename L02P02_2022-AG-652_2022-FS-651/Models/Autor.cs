using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("autores")]
public class Autor
{
    [Key]
    [Column("id")]
    public int Id { get; set; } 

    [Required]
    [Column("autor")]
    public string Nombre { get; set; }
}


