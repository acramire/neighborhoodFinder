using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newCityWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSubmissionStuff3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference",
                table: "Submissions");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiversityImportance",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicTransportationImportance",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SafetyImportance",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SocialImportance",
                table: "Submissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "DiversityImportance",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "PublicTransportationImportance",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "SafetyImportance",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "SocialImportance",
                table: "Submissions");

            migrationBuilder.AddColumn<string>(
                name: "Preference",
                table: "Submissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
