using ProyectoERP.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoERP.Dominio.Interfaces
{
    public interface ISalaryRepository
    {
        void Create(SalaryModel salary);
        IEnumerable<SalaryModel> ListSalaries();
    }
}
