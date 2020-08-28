using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class AddedConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Пользователь_Corporation_ManifacturerId",
                table: "Пользователь");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Corporation",
                table: "Corporation");

            migrationBuilder.RenameTable(
                name: "Corporation",
                newName: "Компании");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Manifacturer",
                table: "Компании",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Компании",
                table: "Компании",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Пользователь_Компании_ManifacturerId",
                table: "Пользователь",
                column: "ManifacturerId",
                principalTable: "Компании",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Пользователь_Компании_ManifacturerId",
                table: "Пользователь");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Компании",
                table: "Компании");

            migrationBuilder.RenameTable(
                name: "Компании",
                newName: "Corporation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Manifacturer",
                table: "Corporation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

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
    }
}
