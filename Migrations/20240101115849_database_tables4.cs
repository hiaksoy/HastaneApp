using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApp.Migrations
{
    public partial class database_tables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoktorId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GunId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaatId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalGunId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalSaatId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CalismaGunleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaGunleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalismaSaatleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaSaatleri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorId",
                table: "Randevular",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_GunId",
                table: "Randevular",
                column: "GunId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_SaatId",
                table: "Randevular",
                column: "SaatId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_CalGunId",
                table: "Doktorlar",
                column: "CalGunId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_CalSaatId",
                table: "Doktorlar",
                column: "CalSaatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_CalismaGunleri_CalGunId",
                table: "Doktorlar",
                column: "CalGunId",
                principalTable: "CalismaGunleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_CalismaSaatleri_CalSaatId",
                table: "Doktorlar",
                column: "CalSaatId",
                principalTable: "CalismaSaatleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorId",
                table: "Randevular",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Gunler_GunId",
                table: "Randevular",
                column: "GunId",
                principalTable: "Gunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Saatler_SaatId",
                table: "Randevular",
                column: "SaatId",
                principalTable: "Saatler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_CalismaGunleri_CalGunId",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_CalismaSaatleri_CalSaatId",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Doktorlar_DoktorId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Gunler_GunId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Saatler_SaatId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "CalismaGunleri");

            migrationBuilder.DropTable(
                name: "CalismaSaatleri");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_DoktorId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_GunId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_SaatId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_CalGunId",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_CalSaatId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "DoktorId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "GunId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "SaatId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "CalGunId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "CalSaatId",
                table: "Doktorlar");
        }
    }
}
