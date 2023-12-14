using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceTest.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompensationRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fund = table.Column<float>(type: "real", nullable: false),
                    DentalFund = table.Column<float>(type: "real", nullable: true),
                    SurgeryFund = table.Column<float>(type: "real", nullable: true),
                    HospitalizationFund = table.Column<float>(type: "real", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterUser = table.Column<int>(type: "int", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangeUser = table.Column<int>(type: "int", nullable: false),
                    Visable = table.Column<bool>(type: "bit", nullable: false),
                    Author = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompensationRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCover",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxFund = table.Column<int>(type: "int", nullable: false),
                    MinFund = table.Column<int>(type: "int", nullable: false),
                    RatePrecentage = table.Column<float>(type: "real", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterUser = table.Column<int>(type: "int", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangeUser = table.Column<int>(type: "int", nullable: false),
                    Visable = table.Column<bool>(type: "bit", nullable: false),
                    Author = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCover", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InsuranceCover",
                columns: new[] { "Id", "Author", "LastChangeDate", "LastChangeUser", "MaxFund", "MinFund", "RatePrecentage", "RegisterDate", "RegisterUser", "Title", "Visable" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(205), 1, 500000000, 5000, 0.0052f, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(222), 1, "پوشش جراحی", true },
                    { 2, 1, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(278), 1, 400000000, 4000, 0.0042f, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(281), 1, "پوشش دندانپزشکی", true },
                    { 3, 1, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(306), 1, 200000000, 2000, 0.005f, new DateTime(2023, 12, 14, 13, 44, 19, 924, DateTimeKind.Local).AddTicks(308), 1, "پوشش بستری", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompensationRequest");

            migrationBuilder.DropTable(
                name: "InsuranceCover");
        }
    }
}
