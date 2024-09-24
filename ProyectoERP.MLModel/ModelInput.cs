using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoERP.MLModel
{
    public class ModelInput
    {
        [ColumnName("YearsExperience"), LoadColumn(0)]
        public float YearsExperience { get; set; }
        [ColumnName("Salary"), LoadColumn(1)]
        public float Salary {  get; set; }
    }
}
