using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantV2.Migrations
{
    /// <inheritdoc />
    public partial class editmeal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_Cart_CartId",
                table: "meals");

            migrationBuilder.DropIndex(
                name: "IX_meals_CartId",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "meals");

            migrationBuilder.CreateTable(
                name: "CartMeal",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    mealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartMeal", x => new { x.CartsId, x.mealsId });
                    table.ForeignKey(
                        name: "FK_CartMeal_Cart_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartMeal_meals_mealsId",
                        column: x => x.mealsId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartMeal_mealsId",
                table: "CartMeal",
                column: "mealsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartMeal");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_meals_CartId",
                table: "meals",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_Cart_CartId",
                table: "meals",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }
    }
}
