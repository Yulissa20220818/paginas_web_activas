namespace Ejemplo_de_inventario.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }

        public string NombreProducto { get; set;}

        public decimal Precio { get; set;}

        public int Cantidad { get; set;}

        public DateTime FechaDeExpiracion { get; set;}
    }
}
