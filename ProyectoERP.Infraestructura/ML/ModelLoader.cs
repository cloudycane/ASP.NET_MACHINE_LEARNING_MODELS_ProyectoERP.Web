using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using ProyectoERP.Infraestructura.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoERP.Infraestructura.ML
{
    public interface IModelLoader
    {

    }

    public class ModelLoader : IModelLoader
    {
        private readonly MLContext _mlContext;
        

        public ModelLoader()
        {
            _mlContext = new MLContext();

        }

        public void PreparePipeline ()
        { 

        }
    }
}
