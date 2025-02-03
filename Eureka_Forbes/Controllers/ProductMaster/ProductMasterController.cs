using System.Text.Json;
using Eureka_Forbes.Data;
using Eureka_Forbes.Models.ProductMaster;
using Eureka_Forbes.ProductModelMaster;
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

        //Read operation on Product added int id in parameter
        public IActionResult GetProductsWithModelsAndSteps()
        {
            List<ProductViewModel> products = _dbContext.GetProductsWithModelsAndSteps();
            return View(products);
            //return View();
        }

        //Method to retreive previous information of products
        public async Task<IActionResult> UpdateProductMaster(int productId)
        {
            var product = await _dbContext.GetProductForUpdate(productId); // Retrieve product, models, and steps
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.stepsList = await _dbContext.GetStepsAsync(); // Get the available steps for editing
            return View(product); // Pass product data to the view
        }

        // Update Product method
        [HttpPut("{productId}")]
        public async Task<JsonResult> UpdateProduct(int productId, [FromBody] ProductMasterUpdateModel productData)
        {
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

                // Call the database method to update product
                bool isUpdated = await _dbContext.UpdateProductMaster(productId, productData);

                if (isUpdated)
                {
                    return Json(new { success = true, message = "Product updated successfully." });
                }

                return Json(new { success = false, message = "Error updating product." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Exception: {ex.Message}" });
            }
        }


        //Delete Product based on ProductId
        [HttpPost]
        public async Task<JsonResult> DeleteProduct(int productId)
        {
            try
            {
                bool isDeleted = await _dbContext.DeleteProduct(productId);
                if (isDeleted)
                {
                    return Json(new { success = true, message = "Product deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error deleting product." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Exception: {ex.Message}" });
            }
        }


        // Get All product and its Models
        public async Task<IActionResult> GetAllProduct()
        {
            var productList = await _dbContext.GetProductModels();
            return View(productList);
        }


    }
}
