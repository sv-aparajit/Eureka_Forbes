namespace Eureka_Forbes.Models.ProductMaster
{
    public class ProductMasterUpdateModel
    {
        public Product Product { get; set; }  
        public List<ProductModelsUpdate> ProductModels { get; set; }  
        public List<StepUpdateModel> ProductModelSteps { get; set; }
    }
}
