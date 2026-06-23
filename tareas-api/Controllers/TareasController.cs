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
        public List<Tarea>ObtenerTodas()
        {
            return new List<Tarea>
            {
                new Tarea { Id = 1, Titulo = "Aprender APIs", Completada = false },
                new Tarea { Id = 2, Titulo = "Probar Swagger", Completada = true }
            };
        }
    }
}
