using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttendanceController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmpAttendanceController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAttendance(EmpAttendanceModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param10 = new SqlParameter("@Attendance", model.Attendance);
            SqlParameter param2 = new SqlParameter("@Date", model.Date);
            SqlParameter param3 = new SqlParameter("@InTime", model.InTime);
            SqlParameter param4 = new SqlParameter("@OutTime", model.OutTime);
            SqlParameter param5 = new SqlParameter("@Permission", model.Permission);
            SqlParameter param6 = new SqlParameter("@IsLate", model.IsLate);
            SqlParameter param7 = new SqlParameter("@Half", model.Half);
            SqlParameter param11 = new SqlParameter("@Notes", model.Notes);
            SqlParameter param8 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param9 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet = 
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmpAttendance @ID, @Attendance, @Date, @InTime, @Outtime," +
                " @Permission,@IsLate,@Half,@Notes, @Creation_Date, @Update_Date", param1, param10, param2, param3, param4, param5, param6, param7, param11, param8, param9);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddAttandence(EmpAttendanceModel model)
        {
            var newEmpAttendance = new EmpAttendanceModel
            {
                Id = Guid.NewGuid(),
                Attendance = model.Attendance,
                Date = model.Date,
                InTime = model.InTime,
                OutTime = model.OutTime,
                Permission = model.Permission,
                IsLate = model.IsLate,
                Half = model.Half,
                Notes = model.Notes,
                //App_User = model.App_User,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Attendances.Add(newEmpAttendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
