namespace Eureka_Forbes.Models.ProductMaster
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<ModelViewModel> Models { get; set; } = new List<ModelViewModel>();
    }
}
