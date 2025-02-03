namespace Eureka_Forbes.Models.ProductMaster
{
    public class ModelViewModel
    {
            public int ModelId { get; set; }
            public string ModelName { get; set; }
            public int ProductId { get; set; }
            public List<StepViewModel> Steps { get; set; } = new List<StepViewModel>();

    }
}
