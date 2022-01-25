using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesWebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id_genero);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    id_pelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    director = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    id_genero = table.Column<int>(type: "int", nullable: false),
                    puntuacion = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    anio_publicacion = table.Column<int>(type: "int", nullable: false),
                    Generoid_genero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.id_pelicula);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Generoid_genero",
                        column: x => x.Generoid_genero,
                        principalTable: "Generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Generoid_genero",
                table: "Peliculas",
                column: "Generoid_genero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
