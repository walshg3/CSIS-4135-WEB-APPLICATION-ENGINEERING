using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab06.Migrations
{
    public partial class changeKeyAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserReview",
                table: "Review",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movie_MovieID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MovieID",
                table: "Review");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserReview",
                table: "Review",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1500);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ID",
                table: "Review",
                column: "ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movie_ID",
                table: "Review",
                column: "ID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
