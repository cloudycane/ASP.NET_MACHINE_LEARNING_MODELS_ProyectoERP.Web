using Microsoft.ML.Data;

namespace ProyectoERP.Web.Models
{
    public class ModelInput
    {
        [ColumnName("YearsExperience"), LoadColumn(0)]
        public float YearsExperience { get; set; }

        [ColumnName("Salary"), LoadColumn(1)]
        public float Salary { get; set; }
    }
}
