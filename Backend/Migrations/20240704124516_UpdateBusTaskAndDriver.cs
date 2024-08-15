using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBusTaskAndDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BusRoutes");

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BusTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BusTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BusTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "BusRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RouteCode",
                table: "BusRoutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RouteName",
                table: "BusRoutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BusTasks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BusTasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BusTasks");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "RouteCode",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "RouteName",
                table: "BusRoutes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BusRoutes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
