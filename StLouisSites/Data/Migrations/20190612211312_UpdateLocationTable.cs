﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisSites.Data.Migrations
{
    public partial class UpdateLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "Locations",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "HoursOfOperation",
            //    table: "Locations",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HoursOfOperation",
                table: "Locations");
        }
    }
}
