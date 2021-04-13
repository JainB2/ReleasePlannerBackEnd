using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class addLob1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dependencies",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdPlanReceive",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdWalkThrough",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RITM",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SPOC",
                table: "Plan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerAccess",
                table: "Plan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dependencies",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "ProdPlanReceive",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "ProdWalkThrough",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "RITM",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "SPOC",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "ServerAccess",
                table: "Plan");
        }
    }
}
