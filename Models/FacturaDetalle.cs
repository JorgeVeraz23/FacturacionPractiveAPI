using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_tareas.Models
{
    public class FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }
        [ForeignKey("FacturaCabecera")]
        public int IdFacturaCabecera { get; set; }
        public string Producto { get; set; }   
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public FacturaCabecera? FacturaCabecera { get; set; }
    }
}
