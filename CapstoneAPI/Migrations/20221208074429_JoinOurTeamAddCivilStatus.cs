using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class JoinOurTeamAddCivilStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CivilStatus",
                table: "JoinOurTeam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CivilStatus",
                table: "JoinOurTeam");
        }
    }
}
