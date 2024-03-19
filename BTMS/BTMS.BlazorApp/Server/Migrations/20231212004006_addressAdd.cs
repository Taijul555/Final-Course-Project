using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMS.BlazorApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class addressAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgentPhoneNumber",
                table: "Agents",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AgentName",
                table: "Agents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AgentEmail",
                table: "Agents",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Agents",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Agents",
                newName: "AgentPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Agents",
                newName: "AgentName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Agents",
                newName: "AgentEmail");
        }
    }
}
