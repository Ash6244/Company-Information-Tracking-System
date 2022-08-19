using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpSalaryController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmpSalaryController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEmpSalary(EmpSalaryModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@Month", model.Month);
            SqlParameter param3 = new SqlParameter("@Year", model.Year);
            SqlParameter param4 = new SqlParameter("@PresentDay", model.PresentDays);
            SqlParameter param5 = new SqlParameter("@AbsentDay", model.AbsentDays);
            SqlParameter param6 = new SqlParameter("@Halfday", model.HalfDays);
            SqlParameter param7 = new SqlParameter("@TotalPermission", model.TotalPermission);
            SqlParameter param8 = new SqlParameter("@TotalLateDays", model.TotalLateDays);
            SqlParameter param9 = new SqlParameter("@BasicSalary", model.BasicSal);
            SqlParameter param10 = new SqlParameter("@LeaveDetect", model.LeaveDetect);
            SqlParameter param11 = new SqlParameter("@LateDetect", model.LateDetect);
            SqlParameter param12 = new SqlParameter("@Advance", model.Advance);
            SqlParameter param13 = new SqlParameter("@NetAmount", model.NetAmount);
            SqlParameter param14 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param15 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet = 
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmpSalary @ID, @Month, @Year, @PresentDay, @AbsentDay,@Halfday,@TotalPermission,@TotalLateDays" +
                " @BasicSalary,@LeaveDetect,@LateDetect,@Advance,@NetAmount @Creation_Date, @Update_Date",
                param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param13, param14,param15);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddSalary(EmpSalaryModel model)
        {
            var newEmpSalary = new EmpSalaryModel
            {
                Id = Guid.NewGuid(),
                Month = model.Month,
                Year = model.Year,
                PresentDays = model.PresentDays,
                AbsentDays = model.AbsentDays,
                HalfDays = model.HalfDays,
                TotalPermission = model.TotalPermission,
                TotalLateDays = model.TotalLateDays,
                BasicSal = model.BasicSal,
                LeaveDetect = model.LeaveDetect,
                LateDetect = model.LateDetect,
                Advance = model.Advance,
                NetAmount = model.NetAmount,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Salaries.Add(newEmpSalary);
            _context.SaveChanges();
            return Ok();
        }
    }
}
