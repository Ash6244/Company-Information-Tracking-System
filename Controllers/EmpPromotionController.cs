using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpPromotionController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmpPromotionController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPromotion(EmpPromotionModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@Current_Designation", model.Current_Designation);
            SqlParameter param3 = new SqlParameter("@Promotional_Designation", model.Promotional_Designation);
            SqlParameter param4 = new SqlParameter("@Date", model.Date);
            SqlParameter param5 = new SqlParameter("@Letter", model.Letter);
            SqlParameter param6 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param7 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet = 
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmpPromotion @ID, @Current_Designation, @Promotional_Designation," +
                " @Date, @Letter, @Creation_Date, @Update_Date",
                param1, param2, param3, param4, param5, param6, param7);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddPromotion(EmpPromotionModel model)
        {
            var newEmpPro = new EmpPromotionModel
            {
                Id = Guid.NewGuid(),
                Current_Designation = model.Current_Designation,
                Promotional_Designation = model.Promotional_Designation,
                Date = model.Date,
                Letter = model.Letter,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Promotions.Add(newEmpPro);
            _context.SaveChanges();
            return Ok();
        }
    }
}
