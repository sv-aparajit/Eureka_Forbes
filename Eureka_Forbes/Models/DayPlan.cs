using System.ComponentModel.DataAnnotations;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Eureka_Forbes.Models
{
    public class DayPlan
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please select Shift")]
        public int ShiftId { get; set; }
        [Required(ErrorMessage = "Please select Product")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please select Product Model")]
        public int ProductModelId { get; set; }
        [Required(ErrorMessage = "Please enter product quantity")]
        public int ProductQunatity { get; set; }
        [Required(ErrorMessage = "Please select Unit")]
        public int UnitId { get; set; }
    }
}
