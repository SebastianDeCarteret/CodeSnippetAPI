using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippet_User_UserId",
                table: "Snippet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Snippet",
                table: "Snippet");

            migrationBuilder.RenameTable(
                name: "Snippet",
                newName: "Snippets");

            migrationBuilder.RenameIndex(
                name: "IX_Snippet_UserId",
                table: "Snippets",
                newName: "IX_Snippets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snippets",
                table: "Snippets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_User_UserId",
                table: "Snippets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_User_UserId",
                table: "Snippets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Snippets",
                table: "Snippets");

            migrationBuilder.RenameTable(
                name: "Snippets",
                newName: "Snippet");

            migrationBuilder.RenameIndex(
                name: "IX_Snippets_UserId",
                table: "Snippet",
                newName: "IX_Snippet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snippet",
                table: "Snippet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippet_User_UserId",
                table: "Snippet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
