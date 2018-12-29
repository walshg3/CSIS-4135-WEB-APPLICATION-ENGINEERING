using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFriendShip.Migrations
{
    public partial class migrationtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsProfilePic = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
