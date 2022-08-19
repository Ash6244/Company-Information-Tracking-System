using Microsoft.AspNetCore.Mvc;
using System;
using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.Data.SqlClient;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEmployee(EmployeeModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@EmpCode", model.EmpCode);
            SqlParameter param3 = new SqlParameter("@Name", model.Name);
            SqlParameter param4 = new SqlParameter("@Address", model.Address);
            SqlParameter param5 = new SqlParameter("@District", model.District);
            SqlParameter param6 = new SqlParameter("@Pin", model.Pin);
            SqlParameter param7 = new SqlParameter("@DOB", model.DOB);
            SqlParameter param8 = new SqlParameter("@ContactNo", model.ContactNo);
            SqlParameter param9 = new SqlParameter("@Email", model.Email);
            SqlParameter param10 = new SqlParameter("@Qualification", model.Qualification);
            SqlParameter param11 = new SqlParameter("@BloodGroup", model.BloodGroup);
            //SqlParameter param12 = new SqlParameter("@Photo", model.Photo);
            SqlParameter param13 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param14 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet = 
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmployee @ID, @EmpCode, @Name, @Address, @District,@Pin,@DOB" +
                " @ContactNo,@Email,@Qualification,@BloodGroup, @Creation_Date, @Update_Date",
                param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param13, param14);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            var newEmp = new EmployeeModel
            {
                Id = Guid.NewGuid(),
                EmpCode = model.EmpCode,
                Name = model.Name,
                Address = model.Address,
                District = model.District,
                Pin = model.Pin,
                DOB = model.DOB,    
                ContactNo = model.ContactNo,
                Email = model.Email,
                Qualification = model.Qualification,
                BloodGroup = model.BloodGroup,
                Creation_Date = DateTime.Now,
                //Update_Date = DateTime.Now                
            };
            _context.Employees.Add(newEmp);
            _context.SaveChanges();
            return Ok(); 
        }
    }
}
