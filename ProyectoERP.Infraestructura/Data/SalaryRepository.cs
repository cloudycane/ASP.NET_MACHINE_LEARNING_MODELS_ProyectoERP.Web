using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Dominio.Interfaces;
using ProyectoERP.Infraestructura.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoERP.Infraestructura.Data
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _context; 

        public SalaryRepository(ApplicationDbContext context) {
            _context = context;
        }

        public IEnumerable<SalaryModel> ListSalaries()
        {
            return _context.Salaries.ToList();
        }
        public void Create(SalaryModel salary)
        {
            _context.Salaries.Add(salary);
            _context.SaveChanges();
        }
    }
}
