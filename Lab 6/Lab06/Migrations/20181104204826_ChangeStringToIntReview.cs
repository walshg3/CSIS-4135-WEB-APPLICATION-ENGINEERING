using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab06.Migrations
{
    public partial class ChangeStringToIntReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieTitle",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieTitle",
                table: "Review",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
