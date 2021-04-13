using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class applob4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_plan",
                table: "plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lob",
                table: "lob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appDetails",
                table: "appDetails");

            migrationBuilder.RenameTable(
                name: "plan",
                newName: "Plan");

            migrationBuilder.RenameTable(
                name: "lob",
                newName: "Lob");

            migrationBuilder.RenameTable(
                name: "appDetails",
                newName: "ApplicationDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lob",
                table: "Lob",
                column: "LobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationDetails",
                table: "ApplicationDetails",
                column: "ApplicationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lob",
                table: "Lob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationDetails",
                table: "ApplicationDetails");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "plan");

            migrationBuilder.RenameTable(
                name: "Lob",
                newName: "lob");

            migrationBuilder.RenameTable(
                name: "ApplicationDetails",
                newName: "appDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plan",
                table: "plan",
                column: "PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lob",
                table: "lob",
                column: "LobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appDetails",
                table: "appDetails",
                column: "ApplicationID");
        }
    }
}
