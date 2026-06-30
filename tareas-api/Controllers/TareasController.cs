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
        public ActionResult<Tarea> BuscarPorId(int id)
        {
            Tarea tarea = _context.Tareas.Find(id);
            ActionResult<Tarea> resultado;

            if(tarea == null)
                resultado = NotFound();

            else
                resultado = Ok(tarea);

            return resultado;
        }
    }
}
