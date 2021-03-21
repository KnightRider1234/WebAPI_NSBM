using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class UpdateModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenLocationsId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CitizenLocationsId",
                table: "Citizens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenLocationsId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CitizenLocationsId",
                table: "Citizens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
