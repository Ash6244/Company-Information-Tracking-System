using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmpAppraisal")]
    public class EmpAppraisalModel
    {
        public Guid Id { get; set; }

        public int EmpCode;
        [ForeignKey("EmpCode")]
        public EmployeeModel Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        [NotMapped]
        public IFormFile OfferLetter { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}
