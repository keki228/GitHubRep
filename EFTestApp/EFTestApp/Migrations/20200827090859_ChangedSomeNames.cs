using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class ChangedSomeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_ManifacturerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Пользователь");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Corporation");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Пользователь",
                newName: "FullName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ManifacturerId",
                table: "Пользователь",
                newName: "IX_Пользователь_ManifacturerId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Corporation",
                newName: "Manifacturer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Пользователь",
                table: "Пользователь",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Corporation",
                table: "Corporation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Пользователь_Corporation_ManifacturerId",
                table: "Пользователь",
                column: "ManifacturerId",
                principalTable: "Corporation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Пользователь_Corporation_ManifacturerId",
                table: "Пользователь");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Пользователь",
                table: "Пользователь");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Corporation",
                table: "Corporation");

            migrationBuilder.RenameTable(
                name: "Пользователь",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Corporation",
                newName: "Companies");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Пользователь_ManifacturerId",
                table: "Users",
                newName: "IX_Users_ManifacturerId");

            migrationBuilder.RenameColumn(
                name: "Manifacturer",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_ManifacturerId",
                table: "Users",
                column: "ManifacturerId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
