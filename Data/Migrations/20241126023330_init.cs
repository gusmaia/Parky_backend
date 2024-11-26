using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parky_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Type = table.Column<string>(type: "CHAR(1)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    IsActive = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fee_VehicleType_VehicleType~",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Available = table.Column<string>(type: "CHAR(1)", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpace_VehicleType_Ve~",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    LicensePlate = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Model = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Color = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    ClientId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_Vehicle~",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingRegistry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    EntryDateTime = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    ExitDateTime = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    TotalValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    ClientId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    VehicleId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    ParkingSpaceId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    FeeId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRegistry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingRegistry_Client_Clie~",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRegistry_Fee_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRegistry_ParkingSpac~",
                        column: x => x.ParkingSpaceId,
                        principalTable: "ParkingSpace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRegistry_Vehicle_Veh~",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CNPJ",
                table: "Client",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_CPF",
                table: "Client",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fee_VehicleTypeId",
                table: "Fee",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistry_ClientId",
                table: "ParkingRegistry",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistry_FeeId",
                table: "ParkingRegistry",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistry_ParkingSpac~",
                table: "ParkingRegistry",
                column: "ParkingSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistry_VehicleId",
                table: "ParkingRegistry",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpace_VehicleTypeId",
                table: "ParkingSpace",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ClientId",
                table: "Vehicle",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRegistry");

            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "ParkingSpace");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
