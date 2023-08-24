using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newCityWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAffordability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AffordabilityImportance",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffordabilityImportance",
                table: "Submissions");
        }
    }
}
