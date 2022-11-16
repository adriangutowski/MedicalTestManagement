using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestBookings_Venues_VenueId",
                table: "TestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueAllocations_Venues_VenueId",
                table: "VenueAllocations");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "VenueAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "TestBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestBookings_Venues_VenueId",
                table: "TestBookings",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueAllocations_Venues_VenueId",
                table: "VenueAllocations",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestBookings_Venues_VenueId",
                table: "TestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueAllocations_Venues_VenueId",
                table: "VenueAllocations");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "VenueAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "TestBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TestBookings_Venues_VenueId",
                table: "TestBookings",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VenueAllocations_Venues_VenueId",
                table: "VenueAllocations",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");
        }
    }
}
