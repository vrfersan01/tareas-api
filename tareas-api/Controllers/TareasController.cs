using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Tarea>> ObtenerTodas()
        {
            List<Tarea> tareas = _context.Tareas.ToList();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> ObtenerPorId(int id)
        {
            Tarea tarea = _context.Tareas.Find(id);
            ActionResult<Tarea> resultado;

            if(tarea == null)
                resultado = NotFound();

            else
                resultado = Ok(tarea);

            return resultado;
        }

        [HttpPost]
        public ActionResult<Tarea> Crear([FromBody] Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Tareas.Add(tarea);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerPorId),
                                    new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarTarea(int id, [FromBody]Tarea datos)
        {
            IActionResult result;

            Tarea tarea = _context.Tareas.Find(id);
            if(tarea == null)
                result = NotFound();
            else
            {
                tarea.Titulo = datos.Titulo;
                tarea.Descripcion = datos.Descripcion;
                tarea.Completada = datos.Completada;
                _context.SaveChanges();
                result = NoContent();
            }
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarTarea(int id)
        {
            IActionResult result;
            Tarea tarea = _context.Tareas.Find(id);

            if(tarea == null)
                result= NotFound();
            else
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
                result= NoContent();
            }
            return result;
        }
    }
}
