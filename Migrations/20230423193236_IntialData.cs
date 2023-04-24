using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace oefproject.Migrations
{
    /// <inheritdoc />
    public partial class IntialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weignt" },
                values: new object[,]
                {
                    { new Guid("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"), null, "Pending tasks", 20 },
                    { new Guid("f53b5019-1a13-489d-86bb-28160188dbd9"), null, "Personal tasks", 50 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreateDt", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("cd12ffd5-c35c-45a6-ba43-013d2402b498"), new Guid("f53b5019-1a13-489d-86bb-28160188dbd9"), new DateTime(2023, 4, 23, 13, 32, 36, 446, DateTimeKind.Local).AddTicks(1923), null, "Low", "Finish movie on netflix" },
                    { new Guid("f2c40001-6c9a-43a4-aeb3-cc7902499e2e"), new Guid("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"), new DateTime(2023, 4, 23, 13, 32, 36, 446, DateTimeKind.Local).AddTicks(1907), null, "Mid", "Payment due public services" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("cd12ffd5-c35c-45a6-ba43-013d2402b498"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f2c40001-6c9a-43a4-aeb3-cc7902499e2e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("f53b5019-1a13-489d-86bb-28160188dbd9"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
