using System.Collections.Generic;
using System.Data;
using Eureka_Forbes.Models;
using Eureka_Forbes.Models.EmployeeMaster;
using Eureka_Forbes.Models.ProductMaster;
using Eureka_Forbes.ProductModelMaster;
using Microsoft.CodeAnalysis;
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
                            ModelId = Convert.ToInt32(rdr["ModelId"]),
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


        public async Task<bool> UpdateProductModel(string jsonData)
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
                            using (SqlCommand cmd = new SqlCommand("spUpdateProductModelMaster", con, transaction))
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
        //clean code

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
                    LEFT JOIN ProductModels m ON p.ProductId = m.ProductId order by p.ProductId desc ", con))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                           // Dictionary<int, ProductModleMasterVM> productDictionary = new Dictionary<int, ProductModleMasterVM>();

                            while (await reader.ReadAsync())
                            {
                                var prosteps = new ProductModleMasterVM
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    ModelId = Convert.ToInt32(reader["ModelId"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    ModelName = reader["ModelName"].ToString()
                                };

                                productList.Add(prosteps);
                            }

                            await con.CloseAsync();
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
        public async Task<DataSet> GetProductModelsById(int id)
        {            
            DataSet dataSet=new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(Con))
                {
                    string query1 = "select  pm.ProductId,pm.ProductName,mo.ModelId,mo.ModelName from ProductMaster pm " +
                        " inner join ProductModels mo on pm.ProductId=mo.ProductId where mo.ModelId="+id+" ";

                    string query2 = " SELECT pm.StepId,pm.StepName,pm.Priority,pm.ModelId FROM [Auto_MenPower_Allocation].[dbo].[ProductStepsMaster] pm" +
                        " inner join ProductModels mo on pm.ModelId=mo.ModelId inner join ProductMaster mst on mo.ProductId=mst.ProductId" +
                        " where pm.ModelId ="+id+" ";
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(" "+query1+ "; "+query2+"", connection);
                   // DataSet dataSet = new DataSet();                    
                    dataAdapter.Fill(dataSet);
                   
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        /// Start Here Fro Employee DB Operation/////////////////
        ///        

        public async Task<DataSet> GetEmployeeStepsAllAsync(int id)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(Con))
                {
                    string query1 = "select * from  ";

                    string query2 = " SELECT pm.StepId,pm.StepName,pm.Priority,pm.ModelId FROM [Auto_MenPower_Allocation].[dbo].[ProductStepsMaster] pm" +
                        " inner join ProductModels mo on pm.ModelId=mo.ModelId inner join ProductMaster mst on mo.ProductId=mst.ProductId" +
                        " where pm.ModelId =" + id + " ";
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(" " + query1 + "; " + query2 + "", connection);
                    // DataSet dataSet = new DataSet();                    
                    dataAdapter.Fill(dataSet);

                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        public async Task<List<ProductMaster>> GetProductAllAsync()
        {
            
            List<ProductMaster> lst = new List<ProductMaster>();
            try
            {
                using (SqlConnection con = new SqlConnection(Con))
                {
                    SqlCommand cmd = new SqlCommand("SELECT [ProductId] ,[ProductName] FROM [dbo].[ProductMaster] ", con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        var prosteps = new ProductMaster
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


    }
}
