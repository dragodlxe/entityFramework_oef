using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oefproject.Migrations
{
    /// <inheritdoc />
    public partial class ColumnWeightCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weignt",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weignt",
                table: "Category");
        }
    }
}
