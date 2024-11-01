using Microsoft.EntityFrameworkCore;
using ApiMySQL2.Model;

namespace ApiMySQL2.Data
{
    public class AlumnoContext : DbContext
    {

        public AlumnoContext(DbContextOptions<AlumnoContext> options) : base(options)
        {

        }

        public DbSet<Alumno> alumnos { get; set; }
    }
}

