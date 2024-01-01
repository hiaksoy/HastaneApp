using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneApp.Migrations
{
    public partial class neww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Doktorlar",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                   
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Doktorlar", x => x.Id);
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
