using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class bitiris : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "oKbxqWLdKhOGzHPfKYkVjA==.ZyzmDaXs/xhjRXVdH4LpKtmB/v3cByZ1iRrYJwOBEpM=");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BusId",
                table: "Tasks",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DriverId",
                table: "Tasks",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RouteId",
                table: "Tasks",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_BusRoutes_RouteId",
                table: "Tasks",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Buses_BusId",
                table: "Tasks",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Drivers_DriverId",
                table: "Tasks",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_BusRoutes_RouteId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Buses_BusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Drivers_DriverId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_BusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DriverId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RouteId",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "JZvXuK/wUJh0Rj8oSa6CnA==.DgjZKks9am0bJMFo0uzndk5dMJT7bXPc4Pjzt904FOY=");
        }
    }
}
