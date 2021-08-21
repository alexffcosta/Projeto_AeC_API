using Microsoft.EntityFrameworkCore.Migrations;

namespace apresentacao.Migrations
{
    public partial class CanAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    vaga_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.vaga_id);
                });

            migrationBuilder.CreateTable(
                name: "candidatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    dtnascimento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    estadocivil = table.Column<string>(type: "varchar", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    logadouro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    telcontato = table.Column<string>(type: "varchar", nullable: false),
                    id_profissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_candidatos_vagas_id_profissao",
                        column: x => x.id_profissao,
                        principalTable: "vagas",
                        principalColumn: "vaga_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidatos_id_profissao",
                table: "candidatos",
                column: "id_profissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidatos");

            migrationBuilder.DropTable(
                name: "vagas");
        }
    }
}
