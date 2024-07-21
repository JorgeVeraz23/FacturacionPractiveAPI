using backend_tareas.Context;
using backend_tareas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TareaController(AplicationDbContext context)
        {
            _context = context;

        }


        [HttpGet("GetAllTarea")]
        public async Task<IActionResult> GetTarea()
        {
            try
            {
                var listaTareas = await _context.Tareas.ToListAsync();

                return Ok(listaTareas);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CrearTarea")]
        public async Task<IActionResult> CrearTarea([FromBody]Tarea tarea)
        {
            try
            {
                 _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();

                return Ok(new { message = "La tarea fue registrada con exito " });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizarTarea(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if(id != tarea.IdTarea)
                {
                    return NotFound();
                }

                tarea.Estado = !tarea.Estado;
                _context.Entry(tarea).State = EntityState.Modified; 
                await _context.SaveChangesAsync();
                return Ok(new {message = "La tarea fue actualizada con exito"});


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if(tarea == null)
                {
                    return NotFound();
                }

                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Tarea eliminada con exito" });
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
