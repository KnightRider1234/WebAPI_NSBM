using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenLocations_Citizens_CitizenId",
                table: "CitizenLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenLocations_Locations_LocationId",
                table: "CitizenLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenLocations",
                table: "CitizenLocations");

            migrationBuilder.RenameTable(
                name: "CitizenLocations",
                newName: "CitizensLocations");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenLocations_LocationId",
                table: "CitizensLocations",
                newName: "IX_CitizensLocations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizensLocations",
                table: "CitizensLocations",
                columns: new[] { "CitizenId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CitizensLocations_Citizens_CitizenId",
                table: "CitizensLocations",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizensLocations_Locations_LocationId",
                table: "CitizensLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizensLocations_Citizens_CitizenId",
                table: "CitizensLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizensLocations_Locations_LocationId",
                table: "CitizensLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizensLocations",
                table: "CitizensLocations");

            migrationBuilder.RenameTable(
                name: "CitizensLocations",
                newName: "CitizenLocations");

            migrationBuilder.RenameIndex(
                name: "IX_CitizensLocations_LocationId",
                table: "CitizenLocations",
                newName: "IX_CitizenLocations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenLocations",
                table: "CitizenLocations",
                columns: new[] { "CitizenId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenLocations_Citizens_CitizenId",
                table: "CitizenLocations",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenLocations_Locations_LocationId",
                table: "CitizenLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
