using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class removeRece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdPlanReceive",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "StgMockPlanReceive",
                table: "Plan",
                newName: "StgMockPlanReceived");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StgMockPlanReceived",
                table: "Plan",
                newName: "StgMockPlanReceive");

            migrationBuilder.AddColumn<string>(
                name: "ProdPlanReceive",
                table: "Plan",
                nullable: true);
        }
    }
}
