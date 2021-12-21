using Microsoft.EntityFrameworkCore.Migrations;

namespace ViagemBella.Migrations
{
    public partial class BancoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    IdPacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diarias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.IdPacote);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true),
                    FK_IdPacote = table.Column<int>(type: "int", nullable: false),
                    PacoteIdPacote = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Pacotes_PacoteIdPacote",
                        column: x => x.PacoteIdPacote,
                        principalTable: "Pacotes",
                        principalColumn: "IdPacote",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteIdCliente",
                table: "Compras",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_PacoteIdPacote",
                table: "Compras",
                column: "PacoteIdPacote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pacotes");
        }
    }
}
