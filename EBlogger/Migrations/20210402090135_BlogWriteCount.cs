using Microsoft.EntityFrameworkCore.Migrations;

namespace EBlogger.Migrations
{
    public partial class BlogWriteCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriteCount",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriteCount",
                table: "Blogs");
        }
    }
}
