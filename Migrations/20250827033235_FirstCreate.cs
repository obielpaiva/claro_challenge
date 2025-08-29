using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Claro.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "sequence_id",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.sequence_id"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descrição = table.Column<string>(type: "varchar(200)", nullable: false),
                    IPdousuario = table.Column<string>(name: "IP do usuario", type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.RequestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropSequence(
                name: "sequence_id",
                schema: "dbo");
        }
    }
}
