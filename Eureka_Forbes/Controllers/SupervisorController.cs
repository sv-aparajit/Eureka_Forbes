using System.Reflection;
using System.Text.Json;
using Eureka_Forbes.Data;
using Eureka_Forbes.Models;
using Eureka_Forbes.Models.ProductMaster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eureka_Forbes.Controllers
{
    public class SupervisorController : Controller
    {
        DbContext _dbContext = new DbContext();
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Planresourceallocation()
        {
            ViewBag.shiftList  = await _dbContext.GetShiftAsync();
            ViewBag.productList  = await _dbContext.GetProductMastersync();
            ViewBag.unitList  = await _dbContext.GetUnitMastersync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Planresourceallocation(DayPlan data)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.shiftList = await _dbContext.GetShiftAsync();
                ViewBag.productList = await _dbContext.GetProductMastersync();
                ViewBag.unitList = await _dbContext.GetUnitMastersync();
                return View(data);
            }
            else
            {
                  _dbContext.PostPlandataAsync(data);
                return RedirectToAction();
            }
            return View();
        }
        public async Task<JsonResult> GetSubProductModel(int productId)
        {
            var subCategories = await _dbContext.GetProductModelsync(productId);
            return Json(subCategories); 
        }
        public IActionResult EmployeeMaster()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult SavePlanSummaryData(DayPlan model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }
        public IActionResult Allocation()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        public async Task<IActionResult> ProductMaster()
        {
            ViewBag.stepsList = await _dbContext.GetStepsAsync();
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SaveProduct([FromBody]  ProductMasterVM productData)
        {
            

            //return Json(new { success = false, message = "Invalid model state" });
            if (productData == null || productData.Product == null || productData.ProductModels == null || productData.ProductModelSteps == null)
            {
                return Json(new { success = false, message = "Invalid data received." });
            }

            try
            {
                // Convert C# object to JSON string
                string jsonData = JsonSerializer.Serialize(productData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Ensures property names are in JSON camelCase format
                });

                // Call the database method
                bool isSaved = await _dbContext.SaveProductModel(jsonData);

                if (isSaved)
                {
                    return Json(new { success = true, message = "Product saved successfully." });
                }

                return Json(new { success = false, message = "Error saving product." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Exception: {ex.Message}" });
            }
            //var subCategories = "";//await _dbContext.SaveProductModel(productData);
            //return Json(subCategories);
            //if (productData == null)
            //{
            //    return Json(new { success = false, message = "Received null data" });
            //}

            //if (ModelState.IsValid)
            //{
            //    var subCategories = await _dbContext.SaveProductModel(productData);
            //    return Json(new { success = true, data = subCategories });
            //}
        }
    }
}
