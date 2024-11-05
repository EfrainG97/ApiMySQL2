using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMySQL2.Data;
using ApiMySQL2.Model;

namespace ApiMySQL2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly AlumnoContext _context;

        public AlumnoController(AlumnoContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            return await _context.alumnos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnoID(int id)
        {
            var alumnoid = await _context.alumnos.FindAsync(id);
            return Ok(alumnoid);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Alumno>>> InsetarAlumno(Alumno alumno)

        {
            _context.alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<IEnumerable<Alumno>>> EliminarAlumno(int id)
        {
            var alumnoelim = await _context.alumnos.FindAsync(id);
            _context.alumnos.Remove(alumnoelim);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
