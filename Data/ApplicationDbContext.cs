using CompanyInfoTrackingSystem.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CompanyInfoTrackingSystem.Data
{
    public class EmployeeDbContext : IdentityDbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmpPromotionModel> Promotions { get; set; }
        public DbSet<EmploymentModel> Employments { get; set; }
        public DbSet<EmpSalaryModel> Salaries { get; set; }
        public DbSet<EmpAdvanceModel> Advances { get; set; }
        public DbSet<EmpAttendanceModel> Attendances { get; set; }
        public DbSet<EmpAppraisalModel> Appraisals { get; set; }

    }
}
