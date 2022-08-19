using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAppraisalController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmpAppraisalController(EmployeeDbContext context)
        {
            _context = context;
        }
        //http
        [HttpGet]
        public IActionResult GetAppraisal(EmpAppraisalModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@Date", model.Date);
            SqlParameter param3 = new SqlParameter("@Amount", model.Amount);
            SqlParameter param4 = new SqlParameter("@Reason", model.Reason);
            SqlParameter param5 = new SqlParameter("@Letter", model.OfferLetter);
            SqlParameter param8 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param9 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet =
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmpAppraisal @ID, @Date, @Amount, @Reason, @Letter," +
                " @Creation_Date, @Update_Date", param1, param2, param3, param4, param5, param8, param9);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddAppraisal(EmpAppraisalModel model)
        {
            var newEmpAppraisal = new EmpAppraisalModel
            {
                Id = Guid.NewGuid(),
                Date = model.Date,
                Amount = model.Amount,
                Reason = model.Reason,
                OfferLetter = model.OfferLetter,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Appraisals.Add(newEmpAppraisal);
            _context.SaveChanges();
            return Ok();
        }
    }
}
