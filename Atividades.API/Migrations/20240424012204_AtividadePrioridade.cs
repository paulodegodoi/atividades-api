using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atividades.API.Migrations
{
    public partial class AtividadePrioridade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Atividades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Atividades");
        }
    }
}
