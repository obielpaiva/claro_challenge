using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Claro.Migrations
{
    /// <inheritdoc />
    public partial class NewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "IP do usuario",
                table: "Ticket",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "IP do usuario",
                table: "Ticket",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "IP do usuario");
        }
    }
}
