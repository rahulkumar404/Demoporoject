using Microsoft.EntityFrameworkCore.Migrations;

namespace IMPrintPro.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffDatas",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaction = table.Column<int>(type: "int", nullable: false),
                    Check = table.Column<int>(type: "int", nullable: false),
                    cuton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDatas", x => x.StaffId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffDatas");
        }
    }
}
