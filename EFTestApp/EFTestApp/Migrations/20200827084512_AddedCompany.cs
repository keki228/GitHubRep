using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class AddedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManifacturerId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ManifacturerId",
                table: "Users",
                column: "ManifacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Company_ManifacturerId",
                table: "Users",
                column: "ManifacturerId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Company_ManifacturerId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Users_ManifacturerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManifacturerId",
                table: "Users");
        }
    }
}
