using System.Data;
using System.Text.Json;
using Eureka_Forbes.Data;
using Eureka_Forbes.Models;
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
        [HttpPost("UpdateProduct/{productId}")]
        // Update Product method
        //[HttpPut("UpdateProduct/{productId}")]
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
                    return Json(new { success = true, message = "Product updated successfully.", redirectUrl = "/ProductMaster/GetProductsWithModelsAndSteps" });
                }

                return Json(new { success = false, message = "Error updating product." });
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Exception in UpdateProduct: {ex}");
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
       
        public async Task<IActionResult> DeleteProductById(int id)
        {
            
             bool isDeleted = await _dbContext.DeleteProduct(id);
            return RedirectToAction("GetAllProduct");
               
        }


        // Get All product and its Models   UpdateModelStepVM
        public async Task<IActionResult> GetAllProduct()
        {
            var productList = await _dbContext.GetProductModels();
            return View(productList);
        }

        public async Task<IActionResult> GetAllProductById(int id)
        {
            UpdateModelStepVM vm = new UpdateModelStepVM();
            DataSet ds = await _dbContext.GetProductModelsById(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                vm.productModleMasterVM = new ProductModleMasterVM
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"].ToString(),
                    ModelId = Convert.ToInt32(row["ModelId"]),
                    ModelName = row["ModelName"].ToString(),

                };
            }
            List<StepsModelMaster> list = new List<StepsModelMaster>();
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                StepsModelMaster stepsModelMasters = new StepsModelMaster
                {
                    StepId = Convert.ToInt32(row["StepId"]),
                    StepName = row["StepName"].ToString(),
                    Priority = Convert.ToInt32(row["Priority"]),

                };
                list.Add(stepsModelMasters);
            }
            vm.stepsModelMasters = list;
            return View(vm);
        }

        public async Task<IActionResult> UpdateProductModel(int id)
        {
            UpdateModelStepVM vm=new UpdateModelStepVM();
           DataSet ds= await _dbContext.GetProductModelsById(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                vm.productModleMasterVM = new ProductModleMasterVM
                {                   
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"].ToString(),
                    ModelId = Convert.ToInt32(row["ModelId"]),
                    ModelName = row["ModelName"].ToString(),
                   
                };
            }
            List<StepsModelMaster> list = new List<StepsModelMaster>();
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                StepsModelMaster stepsModelMasters = new StepsModelMaster
                {
                    StepId = Convert.ToInt32(row["StepId"]),
                    StepName = row["StepName"].ToString(),
                    Priority = Convert.ToInt32(row["Priority"]),                 

                };
                list.Add(stepsModelMasters);
            }
            vm.stepsModelMasters=list;
            List<int> stepIds = vm.stepsModelMasters.Select(s => s.StepId).ToList();

            var stepsList = await _dbContext.GetStepsAsync();
            stepsList = stepsList.Where(step => !stepIds.Contains(step.StepId)).ToList();

            ViewBag.stepsList = stepsList;

            return View(vm);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateProductModel([FromBody] ProductMasterVM productData)
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
                bool isSaved = await _dbContext.UpdateProductModel(jsonData);

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


    }
}
