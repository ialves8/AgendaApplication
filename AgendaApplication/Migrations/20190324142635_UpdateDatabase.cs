using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AgendaApplication.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Contatos_ContatoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_ContatoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "NumeroTelefone",
                table: "Contatos",
                newName: "DescricaoContato");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Contatos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoContatoId",
                table: "Contatos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_TipoContatoId",
                table: "Contatos",
                column: "TipoContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TipoContatos_TipoContatoId",
                table: "Contatos",
                column: "TipoContatoId",
                principalTable: "TipoContatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Pessoas_PessoaId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TipoContatos_TipoContatoId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_TipoContatoId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "TipoContatoId",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "DescricaoContato",
                table: "Contatos",
                newName: "NumeroTelefone");

            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contatos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ContatoId",
                table: "Pessoas",
                column: "ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Contatos_ContatoId",
                table: "Pessoas",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
