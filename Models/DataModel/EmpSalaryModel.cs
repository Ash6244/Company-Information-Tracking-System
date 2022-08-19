using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmpSalary")]
    public class EmpSalaryModel
    {
        public Guid Id { get; set; }

        public int EmpCode;
        [ForeignKey("EmpCode")]
        public EmployeeModel Employee { get; set; }

        [StringLength(10)]
        public string Month { get; set; }

        [StringLength(10)]
        public string Year { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int HalfDays { get; set; }
        public int TotalPermission { get; set; }
        public int TotalLateDays { get; set; }

        [Column(TypeName = "Money")]
        public decimal BasicSal { get; set; }

        [Column(TypeName = "Money")] 
        public decimal Amount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Advance { get; set; }

        [Column(TypeName = "Money")]
        public decimal NetAmount { get; set; }

        public bool LeaveDetect { get; set; }

        public bool LateDetect { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}
