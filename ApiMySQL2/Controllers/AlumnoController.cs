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
    }
}
