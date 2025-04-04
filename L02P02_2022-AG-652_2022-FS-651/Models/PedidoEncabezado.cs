public class PedidoEncabezado
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }
    public int CantidadLibros { get; set; }
    public decimal Total { get; set; }
}

