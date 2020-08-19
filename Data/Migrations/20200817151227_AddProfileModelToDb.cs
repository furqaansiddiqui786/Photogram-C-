using Microsoft.EntityFrameworkCore.Migrations;

namespace Photogram.Data.Migrations
{
    public partial class AddProfileModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "profileId",
                table: "PostsModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileId",
                table: "PostsModel");
        }
    }
}
