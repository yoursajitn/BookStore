using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookShop.Migrations
{
    public partial class addingbookidFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_Booksid",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "Booksid",
                table: "BookGallery",
                newName: "booksid");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_Booksid",
                table: "BookGallery",
                newName: "IX_BookGallery_booksid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_booksid",
                table: "BookGallery",
                column: "booksid",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_booksid",
                table: "BookGallery");

            migrationBuilder.RenameColumn(
                name: "booksid",
                table: "BookGallery",
                newName: "Booksid");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_booksid",
                table: "BookGallery",
                newName: "IX_BookGallery_Booksid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_Booksid",
                table: "BookGallery",
                column: "Booksid",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
