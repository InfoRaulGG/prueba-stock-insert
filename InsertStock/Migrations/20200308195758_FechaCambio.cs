using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsertStock.Migrations
{
    public partial class FechaCambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Inventory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateDate",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
