﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Data.Migrations
{
    public partial class addNameUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameUser",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Empregado",
                columns: table => new
                {
                    EmpregadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCompleto = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    EmpCode = table.Column<string>(type: "varchar(20)", nullable: true),
                    Posicao = table.Column<string>(type: "varchar(100)", nullable: true),
                    LocalizacaoTrabalho = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregado", x => x.EmpregadoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empregado");

            migrationBuilder.DropColumn(
                name: "NameUser",
                table: "AspNetUsers");
        }
    }
}
