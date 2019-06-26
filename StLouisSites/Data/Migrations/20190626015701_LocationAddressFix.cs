using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class LocationAddressFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "Address",
              table: "Locations",
              nullable: true);

            migrationBuilder.AddColumn<string>(
              name: "Region",
              table: "Locations",
              nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Address",
               table: "Locations");

            migrationBuilder.DropColumn(
               name: "Region",
               table: "Locations");

        }
    }
}
