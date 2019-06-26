using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class LocationAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationReviews_Locations_LocationId",
                table: "LocationReviews");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Locations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationReviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationReviews_Locations_LocationId",
                table: "LocationReviews",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationReviews_Locations_LocationId",
                table: "LocationReviews");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationReviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LocationReviews_Locations_LocationId",
                table: "LocationReviews",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
