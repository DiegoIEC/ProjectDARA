using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class budget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Type_TypeId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Category_TypeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transaction",
                newName: "type");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Recurrence",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isRecurring",
                table: "Transaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Limit",
                table: "Category",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "BudgetId", "Description", "Limit", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, 0.0, "Groceries", null },
                    { 2, null, null, 0.0, "Fixed cost", null },
                    { 3, null, null, 0.0, "Utilities", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BudgetId",
                table: "Transaction",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_BudgetId",
                table: "Category",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Budget_BudgetId",
                table: "Category",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Budget_BudgetId",
                table: "Transaction",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Budget_BudgetId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Budget_BudgetId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_BudgetId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Category_BudgetId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Recurrence",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "isRecurring",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Transaction",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_TypeId",
                table: "Category",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Type_TypeId",
                table: "Category",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
