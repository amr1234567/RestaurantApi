using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantV2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isChecked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    recipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isEmpty = table.Column<bool>(type: "bit", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    RateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meals_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_meals_rates_RateId",
                        column: x => x.RateId,
                        principalTable: "rates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDone = table.Column<bool>(type: "bit", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ratesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateUser", x => new { x.UsersId, x.ratesId });
                    table.ForeignKey(
                        name: "FK_RateUser_rates_ratesId",
                        column: x => x.ratesId,
                        principalTable: "rates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateUser_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealOrder",
                columns: table => new
                {
                    mealsId = table.Column<int>(type: "int", nullable: false),
                    ordersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrder", x => new { x.mealsId, x.ordersId });
                    table.ForeignKey(
                        name: "FK_MealOrder_meals_mealsId",
                        column: x => x.mealsId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOrder_orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OrderId",
                table: "Cart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrder_ordersId",
                table: "MealOrder",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_meals_CartId",
                table: "meals",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_meals_RateId",
                table: "meals",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_SellerId",
                table: "orders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RateUser_ratesId",
                table: "RateUser",
                column: "ratesId");

            migrationBuilder.CreateIndex(
                name: "IX_users_CartID",
                table: "users",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_orders_OrderId",
                table: "Cart",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_users_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_orders_OrderId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_users_UserId",
                table: "Cart");

            migrationBuilder.DropTable(
                name: "MealOrder");

            migrationBuilder.DropTable(
                name: "RateUser");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "sellers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
