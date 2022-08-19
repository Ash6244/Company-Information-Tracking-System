using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAdvanceController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmpAdvanceController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAdvance(EmpAdvanceModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@Date", model.Date);
            SqlParameter param3 = new SqlParameter("@Amount", model.Amount);
            SqlParameter param4 = new SqlParameter("@ReceiptNo", model.ReceiptNo);
            SqlParameter param5 = new SqlParameter("@PaymentType", model.PaymentType);
            SqlParameter param6 = new SqlParameter("@GivenBy", model.GivenBy);
            SqlParameter param7 = new SqlParameter("@Reason", model.Reason);
            SqlParameter param8 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param9 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet = Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmpAdvance @ID, @Date, @Amount, @ReceiptNo, @PaymentType, " +
                "@GivenBy,@Reason, @Creation_Date, @Update_Date", param1, param2, param3, param4, param5, param6, param7, param8, param9);
            return Ok(resultSet);
        }
        
        [HttpPost]
        public IActionResult AddAdvance(EmpAdvanceModel model)
        {
            var newEmpAdvance = new EmpAdvanceModel
            {
                Id = Guid.NewGuid(),
                EmpCode = model.EmpCode,
                Date = model.Date,
                Amount = model.Amount,
                ReceiptNo = model.ReceiptNo,
                PaymentType = model.PaymentType,
                GivenBy = model.GivenBy,
                Reason = model.Reason,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Advances.Add(newEmpAdvance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
