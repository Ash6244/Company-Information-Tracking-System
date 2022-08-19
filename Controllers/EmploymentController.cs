using CompanyInfoTrackingSystem.Data;
using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmploymentController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployment(EmploymentModel model)
        {
            SqlParameter param1 = new SqlParameter("@Id", model.Id);
            SqlParameter param2 = new SqlParameter("@Branch", model.Branch);
            SqlParameter param3 = new SqlParameter("@DOJ", model.DOJ);
            SqlParameter param4 = new SqlParameter("@ReferredBy", model.ReferredBy);
            SqlParameter param5 = new SqlParameter("@Department", model.Department);
            SqlParameter param6 = new SqlParameter("@Salary", model.Salary);
            SqlParameter param7 = new SqlParameter("@Designation", model.Designation);
            SqlParameter param8 = new SqlParameter("@Resume", model.Resume);
            SqlParameter param9 = new SqlParameter("@OfferLetter", model.OfferLetter);
            SqlParameter param10 = new SqlParameter("@InTime", model.InTime);
            SqlParameter param11 = new SqlParameter("@OutTime", model.OutTime);
            SqlParameter param12 = new SqlParameter("@Creation_Date", model.Creation_Date);
            SqlParameter param13 = new SqlParameter("@Update_Date", model.Update_Date);

            var resultSet =
                Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(_context.Database, "spEmployment @Id, @Branch, @DOJ, @RefferedBY, @Department, " +
                "@Salary,@Designation,@Resume,@OfferLetter,@InTime,@OutTIme, @Creation_Date, @Update_Date",
                param1, param2, param3, param4, param5, param6,
                param7, param8, param9, param10, param11, param12, param13);
            return Ok(resultSet);
        }
        [HttpPost]
        public IActionResult AddEmployment(EmploymentModel model)
        {
            var newEmployment = new EmploymentModel
            {
                Id = Guid.NewGuid(),
                Branch = model.Branch,
                ReferredBy = model.ReferredBy,
                DOJ = model.DOJ,
                Department = model.Department,
                Designation = model.Designation,
                Resume = model.Resume,
                OfferLetter= model.OfferLetter,
                InTime = model.InTime,
                OutTime = model.OutTime,
                Creation_Date = DateTime.Now,
                Update_Date = DateTime.Now
            };
            _context.Employments.Add(newEmployment);
            _context.SaveChanges();
            return Ok();
        }
        private static IWebHostEnvironment _webHostEnvironment;
        public EmploymentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("api/[controller]/Upload")]
        public async Task<string> Upload([FromForm] EmploymentModel obj)
        {
            if (obj.OfferLetter.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Letters\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Letters\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Letters\\" + obj.OfferLetter.FileName))
                    {
                        obj.OfferLetter.CopyTo(filestream);
                        filestream.Flush();
                        return "\\Letter\\" + obj.OfferLetter.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
