using System.Data;
using Eureka_Forbes.Models;
using Eureka_Forbes.Models.ProductMaster;
using Eureka_Forbes.ProductModelMaster;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Eureka_Forbes.Data
{
    public class DbContext
    {
        //private readonly IConfiguration _configuration;

        //public DbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        string Con = "Data Source=DESKTOP-GNUAT56\\SQLEXPRESS; Initial Catalog=Auto_MenPower_Allocation;integrated security=SSPI;TrustServerCertificate=True;";
        public void GetUserData()
        {
            
            // List<> lst = new List<>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("select * from tblproductStep", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        //var prosteps = new Users
                        //{
                        //    Id = Convert.ToInt32(rdr["Id"]),
                        //    UserName = rdr["stepName"].ToString(),
                        //    Password = rdr["Password"].ToString(),
                        //    EmpId = Convert.ToInt32(rdr["EmpId"]),
                        //    ManagerID = Convert.ToInt32(rdr["ManagerID"])
                        //};

                        //lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return lst;
        }

        public async Task<List<ShiftModel>> GetShiftAsync()
        {
            //string Con = _configuration.GetConnectionString("Conn");
            List<ShiftModel> lst = new List<ShiftModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [ShiftId] ,[ShiftName] FROM [dbo].[ShiftMaster]", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new ShiftModel
                        {
                            ShiftId = Convert.ToInt32(rdr["ShiftId"]),
                            ShiftName = rdr["ShiftName"].ToString()                            
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lst;
            
        }

        public async Task<List<ProdcutModel>> GetProductMastersync()
        {
            List<ProdcutModel> lst = new List<ProdcutModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [ProductId] ,[ProductName] FROM [dbo].[ProductMaster]", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new ProdcutModel
                        {
                            ProductId = Convert.ToInt32(rdr["ProductId"]),
                            ProductName = rdr["ProductName"].ToString()
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lst;            
        }
        public async Task<List<UnitModel>> GetUnitMastersync()
        {
            List<UnitModel> lst = new List<UnitModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [UnitId] ,[UnitName] FROM [dbo].[UnitMaster]", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new UnitModel
                        {
                            UnitId = Convert.ToInt32(rdr["UnitId"]),
                            UnitName = rdr["UnitName"].ToString()
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lst;
        }
        public async Task<List<ProductModel>> GetProductModelsync( int productId)
        {
            List<ProductModel> lst = new List<ProductModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [ProductId] ,[ModelId],[ModelName] FROM [dbo].[ProductModels] where ProductId = " + productId + " ", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new ProductModel
                        {
                            ProductId = Convert.ToInt32(rdr["ProductId"]),
                            ModelName = rdr["ModelName"].ToString()
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lst;
        }

        public void PostPlandataAsync (DayPlan model)
        {
            List<ProductModel> lst = new List<ProductModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [ProductId] ,[ModelId],[ModelName] FROM [dbo].[ProductModels] ", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new ProductModel
                        {
                            ProductId = Convert.ToInt32(rdr["ProductId"]),
                            ModelName = rdr["ModelName"].ToString()
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return lst;
        }

        public async Task<List<Steps>> GetStepsAsync()
        {
            //string Con = _configuration.GetConnectionString("Conn");
            List<Steps> lst = new List<Steps>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [StepId] ,[StepName] FROM [dbo].[StepMaster]", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new Steps
                        {
                            StepId = Convert.ToInt32(rdr["StepId"]),
                            StepName = rdr["StepName"].ToString()
                        };

                        lst.Add(prosteps);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lst;

        }
        //bool earlier strin
        public async Task<bool> SaveProductModel(string jsonData)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    await con.OpenAsync();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("spProductMaster", con, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@JsonData", SqlDbType.NVarChar) { Value = jsonData });

                                await cmd.ExecuteNonQueryAsync();

                                transaction.Commit();
                                return true;
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return false;
            }
            
        }

        //Read Products with models and steps
        public List<ProductViewModel> GetProductsWithModelsAndSteps()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            using (SqlConnection con = new SqlConnection(Con))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetProductsWithModelsAndSteps", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int productId = reader.GetInt32(0);
                            var existingProduct = products.Find(p => p.ProductId == productId);

                            if (existingProduct == null)
                            {
                                existingProduct = new ProductViewModel
                                {
                                    ProductId = productId,
                                    ProductName = reader.GetString(1),
                                    Models = new List<ModelViewModel>()
                                };
                                products.Add(existingProduct);
                            }

                            if (!reader.IsDBNull(2))
                            {
                                int modelId = reader.GetInt32(2);
                                var existingModel = existingProduct.Models.Find(m => m.ModelId == modelId);

                                if (existingModel == null)
                                {
                                    existingModel = new ModelViewModel
                                    {
                                        ModelId = modelId,
                                        ModelName = reader.IsDBNull(3) ? "Unnamed Model" : reader.GetString(3), // Check ModelName for NULL,
                                        ProductId = productId,
                                        Steps = new List<StepViewModel>()
                                    };
                                    existingProduct.Models.Add(existingModel);
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    existingModel.Steps.Add(new StepViewModel
                                    {
                                        StepId = reader.GetInt32(4),
                                        StepName = reader.IsDBNull(5) ? "Unnamed Step" : reader.GetString(5), // Check StepName for NULL
                                        Priority = reader.IsDBNull(6) ? 0 : Convert.ToInt32(reader["Priority"]) // Handle NULL Priority
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return products;
        }

        //Delete Product
        public async Task<bool> DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(Con))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        //Update Product
        public async Task<bool> UpdateProductMaster(int productId, ProductMasterUpdateModel model)
        {
            string jsonData = JsonConvert.SerializeObject(model, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            using (SqlConnection con = new SqlConnection(Con)) // Use your existing connection string
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateProductMaster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@JsonData", jsonData);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        //Retreive Product,model and step to show before editing
        public async Task<ProductMasterUpdateModel> GetProductForUpdate(int productId)
        {
            ProductMasterUpdateModel updateModel = null;

            // SQL Queries for product data, product models, and product steps
            string productQuery = "SELECT ProductId, ProductName FROM ProductMaster WHERE ProductId = @ProductId";
            string modelsQuery = "SELECT ModelId, ModelName FROM ProductModels WHERE ProductId = @ProductId";
            string stepsQuery = "SELECT StepId, StepName, ModelId, Priority FROM ProductStepsMaster WHERE ModelId IN (SELECT ModelId FROM ProductModels WHERE ProductId = @ProductId)";

            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    // Open the connection
                    await con.OpenAsync();

                    // Get Product Data
                    using (SqlCommand cmd = new SqlCommand(productQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            if (rdr.Read())
                            {
                                updateModel = new ProductMasterUpdateModel
                                {
                                    Product = new Product
                                    {
                                        ProductName = rdr.GetString(1) // ProductName only
                                    },
                                    ProductModels = new List<ProductModelsUpdate>(),
                                    ProductModelSteps = new List<StepUpdateModel>()
                                };
                            }
                        }
                    }

                    if (updateModel == null)
                        return null; // If no product is found

                    // Get Product Models
                    using (SqlCommand cmd = new SqlCommand(modelsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            while (rdr.Read())
                            {
                                updateModel.ProductModels.Add(new ProductModelsUpdate
                                {
                                    ModelId = rdr.GetInt32(0),
                                    ModelName = rdr.GetString(1) 
                                });
                            }
                        }
                    }

                    // Get Product Steps related to Models
                    using (SqlCommand cmd = new SqlCommand(stepsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            while (rdr.Read())
                            {
                                updateModel.ProductModelSteps.Add(new StepUpdateModel
                                {
                                    StepId = rdr.IsDBNull(0) ? (int?)null : rdr.GetInt32(0), // Nullability handling for StepId
                                    StepName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                                    Priority = rdr.IsDBNull(3) ? 0 : rdr.GetByte(3) // Nullability handling for Priority
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new Exception("Error retrieving product data", ex);
            }

            return updateModel;
        }

        public async Task<List<ProductModleMasterVM>> GetProductModels()
        {
            List<ProductModleMasterVM> productList = new List<ProductModleMasterVM>();

            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"SELECT 
                    p.ProductId, p.ProductName, 
                    m.ModelId, m.ModelName, m.ProductId 
                    FROM ProductMaster p
                    LEFT JOIN ProductModels m ON p.ProductId = m.ProductId", con))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            Dictionary<int, ProductModleMasterVM> productDictionary = new Dictionary<int, ProductModleMasterVM>();

                            while (await reader.ReadAsync())
                            {
                                int productId = reader["ProductId"] != DBNull.Value ? Convert.ToInt32(reader["ProductId"]) : 0;
                                string productName = reader["ProductName"]?.ToString() ?? "";

                                if (!productDictionary.ContainsKey(productId))
                                {
                                    productDictionary[productId] = new ProductModleMasterVM
                                    {
                                        productMaster = new ProductMaster
                                        {
                                            ProductId = productId,
                                            ProductName = productName
                                        },
                                        modelMasters = new List<ModelMaster>()
                                    };
                                }

                                if (reader["ModelId"] != DBNull.Value)
                                {
                                    productDictionary[productId].modelMasters.Add(new ModelMaster
                                    {
                                        ModelId = Convert.ToInt32(reader["ModelId"]),
                                        ModelName = reader["ModelName"]?.ToString(),
                                        ProductId = productId
                                    });
                                }
                            }

                            productList = productDictionary.Values.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
            }

            return productList;
        }



    }
}
