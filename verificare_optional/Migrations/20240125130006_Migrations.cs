using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace verificare_optional.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeCarte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nr_pagini = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edituras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeEditura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nr_angajati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edituras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autoris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    EdituraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autoris_Edituras_EdituraId",
                        column: x => x.EdituraId,
                        principalTable: "Edituras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelsRelationsAUCT",
                columns: table => new
                {
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsRelationsAUCT", x => new { x.AutorId, x.CarteId });
                    table.ForeignKey(
                        name: "FK_ModelsRelationsAUCT_Autoris_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelsRelationsAUCT_Cartis_CarteId",
                        column: x => x.CarteId,
                        principalTable: "Cartis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autoris_EdituraId",
                table: "Autoris",
                column: "EdituraId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsRelationsAUCT_CarteId",
                table: "ModelsRelationsAUCT",
                column: "CarteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelsRelationsAUCT");

            migrationBuilder.DropTable(
                name: "Autoris");

            migrationBuilder.DropTable(
                name: "Cartis");

            migrationBuilder.DropTable(
                name: "Edituras");
        }
    }
}
