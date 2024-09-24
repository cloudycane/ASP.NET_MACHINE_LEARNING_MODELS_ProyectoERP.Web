using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoERP.Infraestructura.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        { 
        }

        public DbSet<SalaryModel> Salaries { get; set; }
    }
}
