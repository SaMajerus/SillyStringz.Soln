using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    EngineerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.EngineerId);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EngrId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.LicenseId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EngrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "LicenseEngineer",
                columns: table => new
                {
                    LicenseEngineerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LicenseId = table.Column<int>(type: "int", nullable: false),
                    EngrId = table.Column<int>(type: "int", nullable: false),
                    EngineerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseEngineer", x => x.LicenseEngineerId);
                    table.ForeignKey(
                        name: "FK_LicenseEngineer_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseEngineer_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineerMachine",
                columns: table => new
                {
                    EngineerMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    EngrId = table.Column<int>(type: "int", nullable: false),
                    EngineerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerMachine", x => x.EngineerMachineId);
                    table.ForeignKey(
                        name: "FK_EngineerMachine_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenseMachine",
                columns: table => new
                {
                    LicenseMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LicenseId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseMachine", x => x.LicenseMachineId);
                    table.ForeignKey(
                        name: "FK_LicenseMachine_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngineerMachine_EngineerId",
                table: "EngineerMachine",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerMachine_MachineId",
                table: "EngineerMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseEngineer_EngineerId",
                table: "LicenseEngineer",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseEngineer_LicenseId",
                table: "LicenseEngineer",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseMachine_LicenseId",
                table: "LicenseMachine",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseMachine_MachineId",
                table: "LicenseMachine",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineerMachine");

            migrationBuilder.DropTable(
                name: "LicenseEngineer");

            migrationBuilder.DropTable(
                name: "LicenseMachine");

            migrationBuilder.DropTable(
                name: "Engineers");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
