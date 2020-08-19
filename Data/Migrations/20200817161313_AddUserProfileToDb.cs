using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Photogram.Data.Migrations
{
    public partial class AddUserProfileToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfileModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<byte[]>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileModel");
        }
    }
}
