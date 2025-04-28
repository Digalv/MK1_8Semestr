using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK1_8Semestr.Migrations
{
    /// <inheritdoc />
    public partial class categoryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Produkts_ProduktId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProduktId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryProdukt",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProduktsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProdukt", x => new { x.CategoriesId, x.ProduktsId });
                    table.ForeignKey(
                        name: "FK_CategoryProdukt_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProdukt_Produkts_ProduktsId",
                        column: x => x.ProduktsId,
                        principalTable: "Produkts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProdukt_ProduktsId",
                table: "CategoryProdukt",
                column: "ProduktsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProdukt");

            migrationBuilder.AddColumn<Guid>(
                name: "ProduktId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProduktId",
                table: "Categories",
                column: "ProduktId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Produkts_ProduktId",
                table: "Categories",
                column: "ProduktId",
                principalTable: "Produkts",
                principalColumn: "Id");
        }
    }
}
