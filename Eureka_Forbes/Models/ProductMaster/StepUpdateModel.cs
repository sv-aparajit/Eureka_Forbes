namespace Eureka_Forbes.Models.ProductMaster
{
    public class StepUpdateModel
    {
        public int? StepId { get; set; }
        public int Priority { get; set; }  // Priority (0 = delete, >0 = insert/update)
        public string StepName { get; set; }
    }
}
