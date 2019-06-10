using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMVCTest1.Data.Migrations
{
    public partial class hard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strings",
                table: "TestEntity");

            migrationBuilder.AddColumn<string>(
                name: "Hard",
                table: "TestEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hard",
                table: "TestEntity");

            migrationBuilder.AddColumn<string>(
                name: "Strings",
                table: "TestEntity",
                nullable: true);
        }
    }
}
