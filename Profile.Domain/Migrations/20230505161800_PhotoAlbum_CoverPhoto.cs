using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.Domain.Migrations
{
    public partial class PhotoAlbum_CoverPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoUrl",
                table: "PhotoAlbums");

            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId1",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoAlbumId1",
                table: "Photos",
                column: "PhotoAlbumId1",
                unique: true,
                filter: "[PhotoAlbumId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PhotoAlbums_PhotoAlbumId1",
                table: "Photos",
                column: "PhotoAlbumId1",
                principalTable: "PhotoAlbums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_PhotoAlbums_PhotoAlbumId1",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotoAlbumId1",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoAlbumId1",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoUrl",
                table: "PhotoAlbums",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
