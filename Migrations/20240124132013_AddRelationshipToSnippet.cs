using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipToSnippet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Snippet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snippet",
                table: "Snippet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippet_User_UserId",
                table: "Snippet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Snippets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
