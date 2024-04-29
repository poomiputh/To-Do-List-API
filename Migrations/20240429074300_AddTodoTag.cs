using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem");

            migrationBuilder.RenameTable(
                name: "ToDoItem",
                newName: "TodoEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoEntry",
                table: "TodoEntry",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TodoTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoEntryTodoTag",
                columns: table => new
                {
                    TagEntriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoEntryTodoTag", x => new { x.TagEntriesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TodoEntryTodoTag_TodoEntry_TagEntriesId",
                        column: x => x.TagEntriesId,
                        principalTable: "TodoEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoEntryTodoTag_TodoTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TodoTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoEntryTodoTag_TagsId",
                table: "TodoEntryTodoTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoEntryTodoTag");

            migrationBuilder.DropTable(
                name: "TodoTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoEntry",
                table: "TodoEntry");

            migrationBuilder.RenameTable(
                name: "TodoEntry",
                newName: "ToDoItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem",
                column: "Id");
        }
    }
}
