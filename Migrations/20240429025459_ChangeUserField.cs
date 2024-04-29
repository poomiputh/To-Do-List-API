using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TodoEntries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TodoEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntries_Users_UserId",
                table: "TodoEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
