using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApp.Migrations
{
    public partial class database_tables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Poliklinikler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Doktorlar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PoliId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_PoliId",
                table: "Doktorlar",
                column: "PoliId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Poliklinikler_PoliId",
                table: "Doktorlar",
                column: "PoliId",
                principalTable: "Poliklinikler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Poliklinikler_PoliId",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_PoliId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Poliklinikler");

            migrationBuilder.DropColumn(
                name: "PoliId",
                table: "Doktorlar");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Doktorlar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
