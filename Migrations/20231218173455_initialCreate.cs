using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Daires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireNo = table.Column<int>(type: "int", nullable: false),
                    Blok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaireAidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireId = table.Column<int>(type: "int", nullable: false),
                    Dönem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SonÖdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÖdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÖdenenTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AidatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaireAidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaireAidats_Daires_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvSahipleris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sorumlu = table.Column<bool>(type: "bit", nullable: false),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvSahipleris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvSahipleris_Daires_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaireAidats_DaireId",
                table: "DaireAidats",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_EvSahipleris_DaireId",
                table: "EvSahipleris",
                column: "DaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aidats");

            migrationBuilder.DropTable(
                name: "DaireAidats");

            migrationBuilder.DropTable(
                name: "EvSahipleris");

            migrationBuilder.DropTable(
                name: "Daires");
        }
    }
}
