using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyInfoTrackingSystem.Migrations
{
    public partial class CompMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_tblCompany_CompCode",
                table: "tblEmployee");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployee_CompCode",
                table: "tblEmployee");

            migrationBuilder.DropColumn(
                name: "CompCode",
                table: "tblEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompCode",
                table: "tblEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
