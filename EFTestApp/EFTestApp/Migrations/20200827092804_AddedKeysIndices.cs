using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTestApp.Migrations
{
    public partial class AddedKeysIndices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Пользователь",
                table: "Пользователь");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Пользователь",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportInfoINN",
                table: "Пользователь",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportInfoSerialNumber",
                table: "Пользователь",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Пользователь",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "UsersPrimaryKey",
                table: "Пользователь",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Пользователь_Position",
                table: "Пользователь",
                column: "Position");

            migrationBuilder.CreateTable(
                name: "Passport",
                columns: table => new
                {
                    INN = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passport", x => new { x.INN, x.SerialNumber });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Пользователь_FullName",
                table: "Пользователь",
                column: "FullName",
                unique: true,
                filter: "[FullName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Пользователь_PassportInfoINN_PassportInfoSerialNumber",
                table: "Пользователь",
                columns: new[] { "PassportInfoINN", "PassportInfoSerialNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Пользователь_Passport_PassportInfoINN_PassportInfoSerialNumber",
                table: "Пользователь",
                columns: new[] { "PassportInfoINN", "PassportInfoSerialNumber" },
                principalTable: "Passport",
                principalColumns: new[] { "INN", "SerialNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Пользователь_Passport_PassportInfoINN_PassportInfoSerialNumber",
                table: "Пользователь");

            migrationBuilder.DropTable(
                name: "Passport");

            migrationBuilder.DropPrimaryKey(
                name: "UsersPrimaryKey",
                table: "Пользователь");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Пользователь_Position",
                table: "Пользователь");

            migrationBuilder.DropIndex(
                name: "IX_Пользователь_FullName",
                table: "Пользователь");

            migrationBuilder.DropIndex(
                name: "IX_Пользователь_PassportInfoINN_PassportInfoSerialNumber",
                table: "Пользователь");

            migrationBuilder.DropColumn(
                name: "PassportInfoINN",
                table: "Пользователь");

            migrationBuilder.DropColumn(
                name: "PassportInfoSerialNumber",
                table: "Пользователь");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Пользователь");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Пользователь",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Пользователь",
                table: "Пользователь",
                column: "Id");
        }
    }
}
