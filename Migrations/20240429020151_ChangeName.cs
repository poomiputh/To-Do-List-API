using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntryTodoTag_TodoItem_TagEntriesId",
                table: "TodoEntryTodoTag");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntryTodoTag_TodoTag_TagsId",
                table: "TodoEntryTodoTag");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_User_UserId",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTag",
                table: "TodoTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TodoTag",
                newName: "TodoTags");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                newName: "TodoEntries");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItem_UserId",
                table: "TodoEntries",
                newName: "IX_TodoEntries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTags",
                table: "TodoTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoEntries",
                table: "TodoEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntryTodoTag_TodoEntries_TagEntriesId",
                table: "TodoEntryTodoTag",
                column: "TagEntriesId",
                principalTable: "TodoEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntryTodoTag_TodoTags_TagsId",
                table: "TodoEntryTodoTag",
                column: "TagsId",
                principalTable: "TodoTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntryTodoTag_TodoEntries_TagEntriesId",
                table: "TodoEntryTodoTag");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntryTodoTag_TodoTags_TagsId",
                table: "TodoEntryTodoTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTags",
                table: "TodoTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoEntries",
                table: "TodoEntries");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TodoTags",
                newName: "TodoTag");

            migrationBuilder.RenameTable(
                name: "TodoEntries",
                newName: "TodoItem");

            migrationBuilder.RenameIndex(
                name: "IX_TodoEntries_UserId",
                table: "TodoItem",
                newName: "IX_TodoItem_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTag",
                table: "TodoTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntryTodoTag_TodoItem_TagEntriesId",
                table: "TodoEntryTodoTag",
                column: "TagEntriesId",
                principalTable: "TodoItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntryTodoTag_TodoTag_TagsId",
                table: "TodoEntryTodoTag",
                column: "TagsId",
                principalTable: "TodoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_User_UserId",
                table: "TodoItem",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
