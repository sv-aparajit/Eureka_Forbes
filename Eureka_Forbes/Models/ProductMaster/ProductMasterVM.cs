namespace Eureka_Forbes.Models.ProductMaster
{
    public class ProductMasterVM
    {
        public List<Product> Product { get; set; }
        public List<ProductModels> ProductModels { get; set; }
        public List<ProductModelStep> ProductModelSteps { get; set; }
    }


    public class ProductModels
    {
        public string ModelName { get; set; }
    }

    public class ProductModelStep
    {
        public int StepId { get; set; }
        public string StepName { get; set; }
        public int Priority { get; set; }
    }
}


