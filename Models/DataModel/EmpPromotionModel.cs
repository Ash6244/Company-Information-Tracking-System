using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tbEmpPromotion")]
    public class EmpPromotionModel
    {
        public Guid Id { get; set; }

        public int EmpCode;
        [ForeignKey("EmpCode")]
        public EmployeeModel Employee { get; set; }

        [StringLength(50)]
        public string Current_Designation { get; set; }

        [StringLength(50)]
        public string Promotional_Designation { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [NotMapped]
        public IFormFile Letter { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}
