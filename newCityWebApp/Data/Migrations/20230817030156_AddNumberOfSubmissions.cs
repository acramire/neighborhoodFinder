using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newCityWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfSubmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSubmissions",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSubmissions",
                table: "AspNetUsers");
        }
    }
}
