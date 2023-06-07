using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueBud.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRented",
                table: "ChargerLocation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRented",
                table: "ChargerLocation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
