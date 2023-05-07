using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.Domain.Migrations
{
    public partial class User_UserIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProfileUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ProfileUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ProfileUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ProfileUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProfileUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileUsers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProfileUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ProfileUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ProfileUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ProfileUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
