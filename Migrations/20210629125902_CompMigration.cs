using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyInfoTrackingSystem.Migrations
{
    public partial class CompMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompCode",
                table: "tblEmployee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblCompany",
                columns: table => new
                {
                    CompCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    CompContactNo = table.Column<string>(nullable: true),
                    CompanyLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany", x => x.CompCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_CompCode",
                table: "tblEmployee",
                column: "CompCode");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_tblCompany_CompCode",
                table: "tblEmployee",
                column: "CompCode",
                principalTable: "tblCompany",
                principalColumn: "CompCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_tblCompany_CompCode",
                table: "tblEmployee");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployee_CompCode",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "CompCode",
                table: "tblEmployee");
        }
    }
}
