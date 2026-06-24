using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using tareas_api.Models;

namespace tareas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Tarea>> ObtenerTodas()
        {
            return Ok(_tareas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> ObtenerPorId(int id)
        {
            ActionResult<Tarea> resultado;
            Tarea t = _tareas.FirstOrDefault(t => t.Id == id);

            if(t == null)
                resultado = NotFound();

            else
                resultado = Ok(t);

            return resultado;
        }

        [HttpPost]
        public ActionResult<Tarea> CrearTarea([FromBody] Tarea nueva)
        {
            nueva.Id = _siguienteId;
            _siguienteId++;
            nueva.FechaCreacion = DateTime.Now;
            _tareas.Add(nueva);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nueva.Id}, nueva); 
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarTarea(int id, [FromBody] Tarea datos)
        {
            IActionResult resultado;
            Tarea tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if( tarea == null )
                resultado = NotFound();
            else
            {
                tarea.Titulo = datos.Titulo;
                tarea.Descripcion = datos.Descripcion;
                tarea.Completada = datos.Completada;
                resultado = NoContent();
            }

            return resultado;
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarTarea(int id)
        {
            IActionResult resultado;
            Tarea tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if(tarea == null )
                resultado = NotFound();
            else
            {
                _tareas.Remove(tarea);
                resultado = NoContent();
            }

            return resultado;
        }



        private static List<Tarea> _tareas = new List<Tarea>
        {
            new Tarea { Id = 1, Titulo = "Aprender APIs", Completada = false },
            new Tarea { Id = 2, Titulo = "Probar Swagger", Completada = true }
        };
        private static int _siguienteId = 3;
    }
}
