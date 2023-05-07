using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.Domain.Migrations
{
    public partial class User_PhotoAlbum_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "ProfileUsers",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "ProfileUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoUrl",
                table: "PhotoAlbums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "ProfileUsers");

            migrationBuilder.DropColumn(
                name: "CoverPhotoUrl",
                table: "PhotoAlbums");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ProfileUsers",
                newName: "Password");
        }
    }
}
