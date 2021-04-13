using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class newprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stgMockReceived",
                table: "Plan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "stgMockReceived",
                table: "Plan");
        }
    }
}
