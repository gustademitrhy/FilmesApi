using Microsoft.EntityFrameworkCore.Migrations;




#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoAtorNoFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmesId",
                table: "Atores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmesEmCartaz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesDeAcao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atores_FilmesId",
                table: "Atores",
                column: "FilmesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atores_FilmesDeAcao_FilmesId",
                table: "Atores",
                column: "FilmesId",
                principalTable: "FilmesDeAcao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atores_FilmesDeAcao_FilmesId",
                table: "Atores");

            migrationBuilder.DropTable(
                name: "FilmesDeAcao");

            migrationBuilder.DropIndex(
                name: "IX_Atores_FilmesId",
                table: "Atores");

            migrationBuilder.DropColumn(
                name: "FilmesId",
                table: "Atores");
        }
    }
}
