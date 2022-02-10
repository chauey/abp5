using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dna.Abp.Migrations
{
    public partial class Added_AuthorId_To_Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "BsBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BsBooks_AuthorId",
                table: "BsBooks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BsBooks_BsAuthors_AuthorId",
                table: "BsBooks",
                column: "AuthorId",
                principalTable: "BsAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BsBooks_BsAuthors_AuthorId",
                table: "BsBooks");

            migrationBuilder.DropIndex(
                name: "IX_BsBooks_AuthorId",
                table: "BsBooks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BsBooks");
        }
    }
}
