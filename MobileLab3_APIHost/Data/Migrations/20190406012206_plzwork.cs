using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileLab3_APIHost.Data.Migrations
{
    public partial class plzwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_ArtTypes_ArtTypeID",
                table: "Artworks");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_ArtTypes_ArtTypeID",
                table: "Artworks",
                column: "ArtTypeID",
                principalTable: "ArtTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_ArtTypes_ArtTypeID",
                table: "Artworks");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_ArtTypes_ArtTypeID",
                table: "Artworks",
                column: "ArtTypeID",
                principalTable: "ArtTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
