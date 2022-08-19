using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmployement")]
    public class EmploymentModel
    {
        [Key]
        public Guid Id { get; set; }

        public int EmpCode;
        [ForeignKey("EmpCode")]
        public EmployeeModel Employee { get; set; }

        [StringLength(50)]
        public string Branch { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        [StringLength(50)]
        public string ReferredBy { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [NotMapped]
        public IFormFile Resume { get; set; }

        [NotMapped]
        public IFormFile OfferLetter { get; set; }

        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime OutTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}