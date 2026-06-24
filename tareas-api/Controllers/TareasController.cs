using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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



        private static List<Tarea> _tareas = new List<Tarea>
        {
            new Tarea { Id = 1, Titulo = "Aprender APIs", Completada = false },
            new Tarea { Id = 2, Titulo = "Probar Swagger", Completada = true }
        };
        private static int _siguienteId = 3;
    }
}
