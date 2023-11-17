using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantV2.Migrations
{
    /// <inheritdoc />
    public partial class editmeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_Category_categoryId",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "isEmpty",
                table: "meals");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "meals",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_meals_categoryId",
                table: "meals",
                newName: "IX_meals_CategoryID");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "meals",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_Category_CategoryID",
                table: "meals",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_Category_CategoryID",
                table: "meals");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "meals",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_meals_CategoryID",
                table: "meals",
                newName: "IX_meals_categoryId");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEmpty",
                table: "meals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_meals_Category_categoryId",
                table: "meals",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
