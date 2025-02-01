using System.Text.Json;
using Eureka_Forbes.Data;
using Eureka_Forbes.Models.ProductMaster;
using Microsoft.AspNetCore.Mvc;

namespace Eureka_Forbes.Controllers.ProductMaster
{
    public class ProductMasterController : Controller
    {
        DbContext _dbContext = new DbContext();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateProductMaster()
        {
            ViewBag.stepsList = await _dbContext.GetStepsAsync();
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SaveProduct([FromBody] ProductMasterVM productData)
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
        }

        //Read operation on Product
        public IActionResult GetProductsWithModelsAndSteps()
        {
            List<ProductViewModel> products = _dbContext.GetProductsWithModelsAndSteps();
            return View(products);
        }

    }
}
