using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_sample.Migrations
{
    public partial class insertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeName", "Salary", "Skill" },
                values: new object[] { 1, "harish@mail.com", "Harish", 70000f, "Full Stack Developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeName", "Salary", "Skill" },
                values: new object[] { 2, "Ram@mail.com", "Ram", 80000f, "Oracle developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeName", "Salary", "Skill" },
                values: new object[] { 3, "vicky@mail.com", "Vicky", 90000f, "Azure devops developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
