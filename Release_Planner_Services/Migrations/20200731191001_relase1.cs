﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Release_Planner_Services.Migrations
{
    public partial class relase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateStamp",
                table: "ApplicationDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateStamp",
                table: "ApplicationDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDateStamp",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDateStamp",
                table: "ApplicationDetails");
        }
    }
}
