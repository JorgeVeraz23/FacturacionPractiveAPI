namespace backend_tareas.ModelDto
{
    public class FacturaCabeceraDto
    {

    }

    public class FacturaCreateDto
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public List<FacturaDetalleDto> FacturaDetalles { get; set; }
    }

    public class FacturaDetalleDto
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    }

}