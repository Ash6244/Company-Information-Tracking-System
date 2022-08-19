using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyInfoTrackingSystem.Models.DataModel
{
    [Table("tblEmpAttendance")]
    public class EmpAttendanceModel
    {
		public Guid Id { get; set; }

		public int EmpCode;
		[ForeignKey("EmpCode")]
		public EmployeeModel Employee { get; set; }

		public string Attendance { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[DataType(DataType.Time)]
		public DateTime InTime { get; set; }

		[DataType(DataType.Time)]
		public DateTime OutTime { get; set; }

		[StringLength(50)]
		public string Permission { get; set; }

		public bool IsLate { get; set; }

		public bool Half { get; set; }

		[StringLength(250)]
		public string Notes { get; set; }

		//public string App_User { get; set; }

		[DataType(DataType.Date)]
		public DateTime Creation_Date { get; set; }

		[DataType(DataType.Date)]
		public DateTime Update_Date { get; set; }
	}
}
