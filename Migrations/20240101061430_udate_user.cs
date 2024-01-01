using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApp.Migrations
{
    public partial class udate_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "Kullanici",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "Kullanici");
        }
    }
}
