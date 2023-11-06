using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoVendasMVC.Migrations
{
    public partial class AtualizandoTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Cliente");
        }
    }
}
