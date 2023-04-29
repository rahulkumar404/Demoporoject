using Microsoft.EntityFrameworkCore.Migrations;

namespace IMPrintPro.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendorDatas",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaction = table.Column<int>(type: "int", nullable: false),
                    Check = table.Column<int>(type: "int", nullable: false),
                    CutOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorDatas", x => x.VendorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorDatas");
        }
    }
}
