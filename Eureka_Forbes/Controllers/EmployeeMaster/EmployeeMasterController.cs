using Eureka_Forbes.Data;
using Eureka_Forbes.Models.EmployeeMaster;
using Microsoft.AspNetCore.Mvc;

namespace Eureka_Forbes.Controllers.EmployeeMaster
{
    public class EmployeeMasterController : Controller
    {
        DbContext _dbContext = new DbContext();
        public IActionResult GetAllEmployee()
        {
            return View();
        }
        public async Task<IActionResult> AddEmployeeSkillMatrix()
        {
            ViewBag.productList = await _dbContext.GetProductAllAsync();            
            return View();
        }
        public async Task<JsonResult> GetSubProductModel(int productId)
        {
            var subCategories = await _dbContext.GetProductModelsync(productId);
            return Json(subCategories);
        }
        public async Task<JsonResult> GetEmployeeStageMatrix(int modelId)  //GetEmployeeAllAsync
        {
            EmployeeStagesMatrixVM vm=new EmployeeStagesMatrixVM();
            var subCategories = await _dbContext.GetEmployeeStepsAllAsync(modelId);
            return Json(subCategories);
        }
    }
}
