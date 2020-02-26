using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterScraper.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Texto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Texto);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Texto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MensagemHashtag",
                columns: table => new
                {
                    MensagemId = table.Column<Guid>(nullable: false),
                    Hashtag = table.Column<string>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemHashtag", x => new { x.MensagemId, x.Hashtag });
                    table.ForeignKey(
                        name: "FK_MensagemHashtag_Mensagens_MensagemId",
                        column: x => x.MensagemId,
                        principalTable: "Mensagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "MensagemHashtag");

            migrationBuilder.DropTable(
                name: "Mensagens");
        }
    }
}
