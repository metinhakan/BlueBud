using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueBud.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChargerLocation",
                newName: "UserRented");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRented",
                table: "ChargerLocation",
                newName: "UserId");
        }
    }
}
