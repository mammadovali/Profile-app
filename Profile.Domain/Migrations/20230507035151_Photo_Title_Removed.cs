using Microsoft.EntityFrameworkCore.Migrations;

namespace Profile.Domain.Migrations
{
    public partial class Photo_Title_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Photos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId1",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
