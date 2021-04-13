﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Release_Planner_Services.DBContext;

namespace Release_Planner_Services.Migrations
{
    [DbContext(typeof(PlanContext))]
    [Migration("20200930122504_MasterPlanTrntask3")]
    partial class MasterPlanTrntask3
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

                    b.Property<DateTime>("InsertDateStamp");

                    b.Property<int>("LobId");

                    b.Property<DateTime>("UpdateDateStamp");

                    b.HasKey("ApplicationID");

                    b.ToTable("ApplicationDetails");
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

                    b.Property<string>("LobName");

                    b.HasKey("LobId");

                    b.ToTable("Lob");
                });

            modelBuilder.Entity("Release_Planner_Services.Models.MasterPlanTasks", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CratedDateTime");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("FlgActive");

                    b.Property<string>("TaskName");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("TaskId");

                    b.ToTable("MasterPlanTasks");
                });

            modelBuilder.Entity("Release_Planner_Services.Models.MasterPlanTrnTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("Duration");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<int>("PlanId");

                    b.Property<string>("Remarks");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<int>("TaskId");

                    b.Property<string>("TaskName");

                    b.Property<string>("TaskValue");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.ToTable("MasterPlanTrnTasks");
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

                    b.Property<string>("Dependencies");

                    b.Property<int>("Duration");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("Environment");

                    b.Property<int>("LobId");

                    b.Property<string>("LobName");

                    b.Property<DateTime>("PTSTGBaseline");

                    b.Property<int>("ProdFollowUpCount");

                    b.Property<string>("ProdPlanReceived");

                    b.Property<DateTime>("ProdReleaseDate");

                    b.Property<string>("ProdWalkThrough");

                    b.Property<string>("RITM");

                    b.Property<string>("Remarks");

                    b.Property<string>("SPOC");

                    b.Property<string>("ServerAccess");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<string>("Status");

                    b.Property<DateTime>("StgMockPlanReceived");

                    b.Property<int>("StgfollowUpCount");

                    b.Property<DateTime>("TimelineForStagePlanMock");

                    b.Property<DateTime>("TimelinesForPRODUCRPlanBaseline");

                    b.Property<DateTime>("TimelinesForPRODUCRPlanFinalizationWithWalkthroughAndFreeze");

                    b.Property<DateTime>("TimelinesStgPlanFinalizationWithWalkthrough");

                    b.Property<DateTime>("UpdateTimeStamp");

                    b.Property<string>("stgMockReceived");

                    b.HasKey("PlanId");

                    b.ToTable("Plan");
                });
#pragma warning restore 612, 618
        }
    }
}