using Microsoft.EntityFrameworkCore;
using tareas_api.Models;

namespace tareas_api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }


    }
}
