﻿public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

