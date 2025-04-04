public class ComentarioLibro
{
    public int Id { get; set; }
    public int IdLibro { get; set; }
    public Libro Libro { get; set; }
    public string Comentarios { get; set; }
    public string Usuario { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
