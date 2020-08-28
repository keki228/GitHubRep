using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class AddedInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Пользователь",
                columns: new[] { "Id", "Info", "ManifacturerId", "FullName", "PassportInfoINN", "PassportInfoSerialNumber", "Position" },
                values: new object[] { 1, "hz", null, "Nurs", null, null, "Norm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Пользователь",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
