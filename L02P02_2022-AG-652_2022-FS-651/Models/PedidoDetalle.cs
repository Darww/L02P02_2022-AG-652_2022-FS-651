public class PedidoDetalle
{
    public int Id { get; set; }
    public int IdPedido { get; set; }
    public PedidoEncabezado Pedido { get; set; }
    public int IdLibro { get; set; }
    public Libro Libro { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

