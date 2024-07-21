using backend_tareas.Context;
using backend_tareas.ModelDto;
using backend_tareas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public FacturaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ObtenerFacturaPorId{id}")]
        public async Task<ActionResult<FacturaCabecera>> GetFacturaById(int id)
        {
            var factura = await _context.FacturaCabeceras
                .Include(f => f.FacturaDetalles)
                .FirstOrDefaultAsync(f => f.IdFacturaCabecera == id);

            if(factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        [HttpGet("ObtenerTodasLasFacturaConDetalles")]
        public async Task<ActionResult<List<FacturaCabecera>>> ObtenerTodasLasFacturaConDetalles()
        {
            var facturas = await _context.FacturaCabeceras
                .Include(f => f.FacturaDetalles)
                .ToListAsync();

            return facturas;
        }


        [HttpPost("CrearFactura")]
        public async Task<ActionResult<FacturaCabecera>> CrearFactura(FacturaCreateDto facturaDto)
        {
            var facturaCabecera = new FacturaCabecera
            {
                NumeroFactura = facturaDto.NumeroFactura,
                Fecha = facturaDto.Fecha,
                FacturaDetalles = facturaDto.FacturaDetalles.Select(d => new FacturaDetalle
                {
                    Producto = d.Producto,
                    Precio = d.Precio,
                    Cantidad = d.Cantidad,
                }).ToList()
            };

            _context.FacturaCabeceras.Add(facturaCabecera);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacturaById), new { id = facturaCabecera.IdFacturaCabecera }, facturaCabecera);
        }
    }
}
