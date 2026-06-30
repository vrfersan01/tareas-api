using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using tareas_api.Data;
using tareas_api.Models;

namespace tareas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TareasController(AppDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> ObtenerTodas()
        {
            List<Tarea> tareas = await _context.Tareas.ToListAsync();

            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerPorId(int id)
        {
            Tarea tarea = await _context.Tareas.FindAsync(id);

            ActionResult<Tarea> resultado;

            if(tarea == null)
                resultado = NotFound();

            else
                resultado = Ok(tarea);

            return resultado;
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> Crear([FromBody] Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId),
                                    new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTarea(int id, [FromBody]Tarea datos)
        {
            IActionResult result;

            Tarea tarea = await _context.Tareas.FindAsync(id);
            if(tarea == null)
                result = NotFound();
            else
            {
                tarea.Titulo = datos.Titulo;
                tarea.Descripcion = datos.Descripcion;
                tarea.Completada = datos.Completada;
                await _context.SaveChangesAsync();
                result = NoContent();
            }
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarTarea(int id)
        {
            IActionResult result;
            Tarea tarea = await _context.Tareas.FindAsync(id);

            if(tarea == null)
                result= NotFound();
            else
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
                result= NoContent();
            }
            return result;
        }
    }
}
