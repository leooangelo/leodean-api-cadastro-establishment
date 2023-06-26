using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Establishment.Infra.DataAccess.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    EstablishmentID = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, defaultValueSql: "NEWID()"),
                    FantasyName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    CorporateName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    SACPhone = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    TelesalesPhone = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    OpeningHours = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClosingHours = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddressID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.EstablishmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establishment");
        }
    }
}
