using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Establishment.Infra.DataAccess.Migrations
{
    public partial class ajuste_CNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Establishment",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Establishment",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);
        }
    }
}
