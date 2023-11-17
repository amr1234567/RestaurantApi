using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantV2.Migrations
{
    /// <inheritdoc />
    public partial class editmeal3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_rates_RateId",
                table: "meals");

            migrationBuilder.DropIndex(
                name: "IX_meals_RateId",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "meals");

            migrationBuilder.CreateTable(
                name: "MealRate",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    RatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRate", x => new { x.MealsId, x.RatesId });
                    table.ForeignKey(
                        name: "FK_MealRate_meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRate_rates_RatesId",
                        column: x => x.RatesId,
                        principalTable: "rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealRate_RatesId",
                table: "MealRate",
                column: "RatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealRate");

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_meals_RateId",
                table: "meals",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_rates_RateId",
                table: "meals",
                column: "RateId",
                principalTable: "rates",
                principalColumn: "Id");
        }
    }
}
