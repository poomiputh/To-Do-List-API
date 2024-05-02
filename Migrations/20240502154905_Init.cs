using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTags", x => x.Id);
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
                        name: "FK_TodoEntryTodoTag_TodoEntries_TagEntriesId",
                        column: x => x.TagEntriesId,
                        principalTable: "TodoEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoEntryTodoTag_TodoTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TodoTags",
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
                name: "TodoEntries");

            migrationBuilder.DropTable(
                name: "TodoTags");
        }
    }
}
