using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace congestion.calculator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    MaxFee = table.Column<int>(nullable: false),
                    TimeSingleChargeRule = table.Column<int>(nullable: true),
                    LimitedYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tollFreeDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    FreeDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tollFreeDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tollFreeDates_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tollTimeFees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    FromTime = table.Column<TimeSpan>(nullable: false),
                    ToTime = table.Column<TimeSpan>(nullable: false),
                    Fee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tollTimeFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tollTimeFees_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tollFreeVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tollFreeVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tollFreeVehicles_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tollFreeVehicles_vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tollFreeDates_CityId",
                table: "tollFreeDates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tollFreeVehicles_CityId",
                table: "tollFreeVehicles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tollFreeVehicles_VehicleId",
                table: "tollFreeVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_tollTimeFees_CityId",
                table: "tollTimeFees",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tollFreeDates");

            migrationBuilder.DropTable(
                name: "tollFreeVehicles");

            migrationBuilder.DropTable(
                name: "tollTimeFees");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
