using Microsoft.EntityFrameworkCore.Migrations;

namespace PortnoxNetworkEvents.ConsoleApp.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkEvents",
                columns: table => new
                {
                    Event_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Switch_Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port_Id = table.Column<int>(type: "int", nullable: false),
                    Device_Mac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkEvents", x => x.Event_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkEvents");
        }
    }
}
