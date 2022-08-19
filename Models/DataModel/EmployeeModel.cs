using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmployee")]
    public class EmployeeModel
    {
        //public int CompCode { get; set; }
        //[ForeignKey("CompCode")]
        //public CompanyModel Company { get; set; }

        public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        public int Pin { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(10)]
        public string ContactNo { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Qualification { get; set; }

        [StringLength(50)]
        public string BloodGroup { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        //public string PhotoURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime Creation_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Update_Date { get; set; }
    }
}