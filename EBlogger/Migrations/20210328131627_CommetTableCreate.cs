using Microsoft.EntityFrameworkCore.Migrations;

namespace EBlogger.Migrations
{
    public partial class CommetTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Commets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Commets",
                columns: new[] { "Id", "BlogId", "Message" },
                values: new object[] { 1, 1, "I know Tesla" });

            migrationBuilder.InsertData(
                table: "Commets",
                columns: new[] { "Id", "BlogId", "Message" },
                values: new object[] { 2, 2, "I know IPhone" });

            migrationBuilder.InsertData(
                table: "Commets",
                columns: new[] { "Id", "BlogId", "Message" },
                values: new object[] { 3, 1, "I know SpaceX" });

            migrationBuilder.CreateIndex(
                name: "IX_Commets_BlogId",
                table: "Commets",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commets_Blogs_BlogId",
                table: "Commets",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commets_Blogs_BlogId",
                table: "Commets");

            migrationBuilder.DropIndex(
                name: "IX_Commets_BlogId",
                table: "Commets");

            migrationBuilder.DeleteData(
                table: "Commets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Commets");
        }
    }
}
