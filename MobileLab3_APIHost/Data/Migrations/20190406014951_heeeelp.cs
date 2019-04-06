using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileLab3_APIHost.Data.Migrations
{
    public partial class heeeelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artworks_ArtTypeID_Name",
                table: "Artworks");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtTypeID",
                table: "Artworks",
                column: "ArtTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_Name",
                table: "Artworks",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artworks_ArtTypeID",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_Name",
                table: "Artworks");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtTypeID_Name",
                table: "Artworks",
                columns: new[] { "ArtTypeID", "Name" },
                unique: true);
        }
    }
}
