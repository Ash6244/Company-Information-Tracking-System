using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmpAdvance")]
    public class EmpAdvanceModel
    {
        public Guid Id { get; set; }

        public int EmpCode { get; set; }
        [ForeignKey("EmpCode")]
        public EmployeeModel Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public int ReceiptNo { get; set; }

        [StringLength(30)]
        public string PaymentType { get; set; }

        public string GivenBy { get; set; }

        [StringLength(150)]
        public string Reason { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}
