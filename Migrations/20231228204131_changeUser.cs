using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApp.Migrations
{
    public partial class changeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adSoyad",
                table: "Kullanici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adSoyad",
                table: "Kullanici",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
