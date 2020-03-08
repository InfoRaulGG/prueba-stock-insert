using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsertStock.Migrations
{
    public partial class PruebaFecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateDate",
                table: "Inventory",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
