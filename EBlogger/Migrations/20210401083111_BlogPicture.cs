using Microsoft.EntityFrameworkCore.Migrations;

namespace EBlogger.Migrations
{
    public partial class BlogPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blogs");
        }
    }
}
