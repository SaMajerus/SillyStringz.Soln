using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class RenamePKofEngineersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseEngineer_Engineers_EngineerId",
                table: "LicenseEngineer");

            migrationBuilder.DropColumn(
                name: "EngrId",
                table: "LicenseEngineer");

            migrationBuilder.DropColumn(
                name: "EngrId",
                table: "EngineerMachine");

            migrationBuilder.RenameColumn(
                name: "EngrId",
                table: "Machines",
                newName: "EngineerId");

            migrationBuilder.RenameColumn(
                name: "EngrId",
                table: "Licenses",
                newName: "EngineerId");

            migrationBuilder.AlterColumn<int>(
                name: "EngineerId",
                table: "LicenseEngineer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngineerId",
                table: "EngineerMachine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseEngineer_Engineers_EngineerId",
                table: "LicenseEngineer",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseEngineer_Engineers_EngineerId",
                table: "LicenseEngineer");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Machines",
                newName: "EngrId");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Licenses",
                newName: "EngrId");

            migrationBuilder.AlterColumn<int>(
                name: "EngineerId",
                table: "LicenseEngineer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EngrId",
                table: "LicenseEngineer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EngineerId",
                table: "EngineerMachine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EngrId",
                table: "EngineerMachine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Engineers_EngineerId",
                table: "EngineerMachine",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseEngineer_Engineers_EngineerId",
                table: "LicenseEngineer",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
