﻿// <auto-generated />
using System;
using Release_Planner_Services.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Release_Planner_Services.Migrations
{
    [DbContext(typeof(PlanContext))]
    [Migration("20200731165344_applob1")]
    partial class applob1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Release_Planner_Services.Models.ApplicationDetails", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationName");

                    b.Property<string>("FlgActive")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int>("LobId");

                    b.HasKey("ApplicationID");

                    b.ToTable("appDetails");
                });

            modelBuilder.Entity("Release_Planner_Services.Models.LOB", b =>
                {
                    b.Property<int>("LobId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FlgActive")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("LOBName");

                    b.HasKey("LobId");

                    b.ToTable("lob");
                });

            modelBuilder.Entity("Release_Planner_Services.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ATSTGBaseline");

                    b.Property<DateTime>("ActualTimelinesForStagePlanMock");

                    b.Property<DateTime>("ActualTimelinesforStageplanFinalization");

                    b.Property<int>("ApplicationId");

                    b.Property<string>("ApplicationName");

                    b.Property<DateTime>("CreatedTimeStamp");

                    b.Property<string>("Environment");

                    b.Property<DateTime>("PTSTGBaseline");

                    b.Property<int>("ProdFollowUpCount");

                    b.Property<DateTime>("ProdReleaseDate");

                    b.Property<DateTime>("StgMockPlanReceive");

                    b.Property<int>("StgfollowUpCount");

                    b.Property<DateTime>("TimelineForStagePlanMock");

                    b.Property<DateTime>("TimelinesForPRODUCRPlanBaseline");

                    b.Property<DateTime>("TimelinesForPRODUCRPlanFinalizationWithWalkthroughAndFreeze");

                    b.Property<DateTime>("TimelinesStgPlanFinalizationWithWalkthrough");

                    b.Property<DateTime>("UpdateTimeStamp");

                    b.HasKey("PlanId");

                    b.ToTable("plan");
                });
#pragma warning restore 612, 618
        }
    }
}
