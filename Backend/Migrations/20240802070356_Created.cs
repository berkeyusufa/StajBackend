using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "PR6hdSPX8o9tEv43j8+Aow==.tZnpBBAEhVXbPnhhYFfvn8fKiznO9B1ux9DETjDu8sU=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "T/zYCOQMrPYf26SqNPtiCg==.DamFJcy+jfPHfn6hO1GoimHib2yyFahzeIY6fFvFjuE=");
        }
    }
}
