using Microsoft.EntityFrameworkCore.Migrations;

namespace Photogram.Data.Migrations
{
    public partial class AddLinkToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "AspNetUsers");
        }
    }
}
