using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plan",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationId = table.Column<int>(nullable: false),
                    ApplicationName = table.Column<string>(nullable: true),
                    Environment = table.Column<string>(nullable: true),
                    ProdReleaseDate = table.Column<DateTime>(nullable: false),
                    StgMockPlanReceive = table.Column<DateTime>(nullable: false),
                    PTSTGBaseline = table.Column<DateTime>(nullable: false),
                    ATSTGBaseline = table.Column<DateTime>(nullable: false),
                    TimelinesStgPlanFinalizationWithWalkthrough = table.Column<DateTime>(nullable: false),
                    ActualTimelinesforStageplanFinalization = table.Column<DateTime>(nullable: false),
                    TimelineForStagePlanMock = table.Column<DateTime>(nullable: false),
                    ActualTimelinesForStagePlanMock = table.Column<DateTime>(nullable: false),
                    TimelinesForPRODUCRPlanBaseline = table.Column<DateTime>(nullable: false),
                    TimelinesForPRODUCRPlanFinalizationWithWalkthroughAndFreeze = table.Column<DateTime>(nullable: false),
                    ProdFollowUpCount = table.Column<int>(nullable: false),
                    StgfollowUpCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan", x => x.PlanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plan");
        }
    }
}
