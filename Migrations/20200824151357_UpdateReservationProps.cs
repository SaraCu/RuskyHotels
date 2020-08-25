using Microsoft.EntityFrameworkCore.Migrations;

namespace RuskyHotels.Migrations
{
    public partial class UpdateReservationProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Rusky",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Rusky",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Rusky",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Rusky",
                table: "Reservations");
        }
    }
}
