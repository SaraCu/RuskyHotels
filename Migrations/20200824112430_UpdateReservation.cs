using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuskyHotels.Migrations
{
    public partial class UpdateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests",
                schema: "Rusky");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GuestId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                schema: "Rusky",
                table: "Reservations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "Rusky",
                table: "Reservations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Rusky",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                schema: "Rusky",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                schema: "Rusky",
                table: "Reservations",
                column: "UserId",
                principalSchema: "Rusky",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Rusky",
                table: "Reservations");

            migrationBuilder.AddColumn<long>(
                name: "GuestId",
                schema: "Rusky",
                table: "Reservations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Guests",
                schema: "Rusky",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestId",
                schema: "Rusky",
                table: "Reservations",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                schema: "Rusky",
                table: "Reservations",
                column: "GuestId",
                principalSchema: "Rusky",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
