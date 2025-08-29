using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Claro.Migrations
{
    /// <inheritdoc />
    public partial class fourCommit : Migration
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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR dbo.sequence_id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "NEXT VALUE FOR dbo.sequence_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "IP do usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR dbo.sequence_id",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR dbo.sequence_id");

            migrationBuilder.AlterColumn<string>(
                name: "IP do usuario",
                table: "Ticket",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "RequestId");
        }
    }
}
