using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyInfoTrackingSystem.Migrations
{
    public partial class CompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    EmpCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    District = table.Column<string>(maxLength: 50, nullable: true),
                    Pin = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Qualification = table.Column<string>(maxLength: 50, nullable: true),
                    BloodGroup = table.Column<string>(maxLength: 50, nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.EmpCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEmpPromotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Current_Designation = table.Column<string>(maxLength: 50, nullable: true),
                    Promotional_Designation = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmpPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbEmpPromotion_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpAdvance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    ReceiptNo = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(maxLength: 30, nullable: true),
                    GivenBy = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(maxLength: 150, nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAdvance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpAdvance_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpAppraisal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    Reason = table.Column<string>(maxLength: 50, nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAppraisal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpAppraisal_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpAttendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Attendance = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InTime = table.Column<DateTime>(nullable: false),
                    OutTime = table.Column<DateTime>(nullable: false),
                    Permission = table.Column<string>(maxLength: 50, nullable: true),
                    IsLate = table.Column<bool>(nullable: false),
                    Half = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(maxLength: 250, nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpAttendance_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Branch = table.Column<string>(maxLength: 50, nullable: true),
                    DOJ = table.Column<DateTime>(nullable: false),
                    ReferredBy = table.Column<string>(maxLength: 50, nullable: true),
                    Department = table.Column<string>(maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "Money", nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: true),
                    InTime = table.Column<DateTime>(nullable: false),
                    OutTime = table.Column<DateTime>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployement_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmpSalary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpCode = table.Column<int>(nullable: false),
                    Month = table.Column<string>(maxLength: 10, nullable: true),
                    Year = table.Column<string>(maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PresentDays = table.Column<int>(nullable: false),
                    AbsentDays = table.Column<int>(nullable: false),
                    HalfDays = table.Column<int>(nullable: false),
                    TotalPermission = table.Column<int>(nullable: false),
                    TotalLateDays = table.Column<int>(nullable: false),
                    BasicSal = table.Column<decimal>(type: "Money", nullable: false),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    Advance = table.Column<decimal>(type: "Money", nullable: false),
                    NetAmount = table.Column<decimal>(type: "Money", nullable: false),
                    LeaveDetect = table.Column<bool>(nullable: false),
                    LateDetect = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Update_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpSalary_tblEmployee_EmpCode",
                        column: x => x.EmpCode,
                        principalTable: "tblEmployee",
                        principalColumn: "EmpCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbEmpPromotion_EmpCode",
                table: "tbEmpPromotion",
                column: "EmpCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAdvance_EmpCode",
                table: "tblEmpAdvance",
                column: "EmpCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAppraisal_EmpCode",
                table: "tblEmpAppraisal",
                column: "EmpCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAttendance_EmpCode",
                table: "tblEmpAttendance",
                column: "EmpCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployement_EmpCode",
                table: "tblEmployement",
                column: "EmpCode");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpSalary_EmpCode",
                table: "tblEmpSalary",
                column: "EmpCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbEmpPromotion");

            migrationBuilder.DropTable(
                name: "tblEmpAdvance");

            migrationBuilder.DropTable(
                name: "tblEmpAppraisal");

            migrationBuilder.DropTable(
                name: "tblEmpAttendance");

            migrationBuilder.DropTable(
                name: "tblEmployement");

            migrationBuilder.DropTable(
                name: "tblEmpSalary");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblEmployee");
        }
    }
}
