using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Infraestructura.DataAccess;
using ProyectoERP.MLModel;
using System.Linq;

public class SalaryController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly MLContext _mlContext;

    public SalaryController(ApplicationDbContext context)
    {
        _context = context;
        _mlContext = new MLContext();
    }

    // Index view to show form for input
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(SalaryModel salary)
    {
        if (ModelState.IsValid)
        {
            _context.Salaries.Add(salary);
            _context.SaveChanges();
            return RedirectToAction(nameof(PredictSalary), new { yearsExperience = salary.YearsExperienced});
        }
        return View(salary);
    }

    public IActionResult PredictSalary(float yearsExperience)
    {
        // Load data from the database
        var salaryData = _context.Salaries.ToList();

        // Convert to IDataView
        IDataView dataView = _mlContext.Data.LoadFromEnumerable(salaryData.Select(s => new ModelInput
        {
            YearsExperience = s.YearsExperienced,
            Salary = s.SalaryAmount
        }));

        // Prepare the pipeline
        var pipeline = _mlContext.Transforms.Concatenate("Features", new[] { "YearsExperience" })
                            .Append(_mlContext.Transforms.NormalizeMinMax("Features", "Features"))
                            .Append(_mlContext.Regression.Trainers.Ols(labelColumnName: "Salary", featureColumnName: "Features"));

        // Train the model
        var model = pipeline.Fit(dataView);

        // Create a prediction engine
        var predEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);

        // Predict the salary based on the input years of experience
        var input = new ModelInput { YearsExperience = yearsExperience };
        var prediction = predEngine.Predict(input);

        // Return prediction result to the view
        ViewBag.PredictedSalary = prediction.Score;
        ViewBag.YearsExperience = yearsExperience;
        return View();
    }
}
