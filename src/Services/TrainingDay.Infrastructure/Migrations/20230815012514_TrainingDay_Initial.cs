using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingDay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrainingDayInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TrainingDay");

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "TrainingDay",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills",
                schema: "TrainingDay");
        }
    }
}
