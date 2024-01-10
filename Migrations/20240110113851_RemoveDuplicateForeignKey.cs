using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippet_User_UserId1",
                table: "Snippet");

            migrationBuilder.DropIndex(
                name: "IX_Snippet_UserId1",
                table: "Snippet");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Snippet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Snippet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Snippet_UserId",
                table: "Snippet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippet_User_UserId",
                table: "Snippet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippet_User_UserId",
                table: "Snippet");

            migrationBuilder.DropIndex(
                name: "IX_Snippet_UserId",
                table: "Snippet");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Snippet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Snippet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snippet_UserId1",
                table: "Snippet",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippet_User_UserId1",
                table: "Snippet",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
