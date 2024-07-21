using System.ComponentModel.DataAnnotations;

namespace backend_tareas.Models
{
    public class FacturaCabecera
    {
        [Key]
        public int IdFacturaCabecera { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<FacturaDetalle>? FacturaDetalles { get; set; }

    }
}
