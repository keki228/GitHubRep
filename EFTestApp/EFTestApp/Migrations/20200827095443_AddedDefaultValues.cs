using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class AddedDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Пользователь",
                nullable: false,
                defaultValue: 18,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Пользователь",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Пользователь",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Пользователь");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Пользователь");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Пользователь",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 18);
        }
    }
}
