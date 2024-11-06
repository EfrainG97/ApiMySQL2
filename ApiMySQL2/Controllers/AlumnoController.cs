using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMySQL2.Data;
using ApiMySQL2.Model;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult<Alumno>> GetAlumnoID(int id)
        {
            var alumnoid = await _context.alumnos.FindAsync(id);
            return Ok(alumnoid);
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> InsetarAlumno(Alumno alumno)

        {
            _context.alumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Alumno>> EliminarAlumno(int id)
        {
            var alumnoelim = await _context.alumnos.FindAsync(id);
            if (alumnoelim == null)
            {
                return NotFound();
            }
            _context.alumnos.Remove(alumnoelim);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (id != alumno.ID)
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.alumnos.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }

}
