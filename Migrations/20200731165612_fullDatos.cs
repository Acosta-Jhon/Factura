using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace factura.Migrations
{
    public partial class fullDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Categoria_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria_nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Persona_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Persona_Apellido = table.Column<string>(maxLength: 50, nullable: true),
                    Persona_Email = table.Column<string>(maxLength: 50, nullable: true),
                    Persona_Fecha_Nacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Persona_Telefono = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personas__2C9075C05E820E0E", x => x.Persona_Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Productos_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productos_nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Productos_precio = table.Column<double>(nullable: true),
                    Categoria_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Productos_id);
                    table.ForeignKey(
                        name: "FK__Productos__Categ__25869641",
                        column: x => x.Categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "Categoria_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Factura_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factura_descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    Persona_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Factura_id);
                    table.ForeignKey(
                        name: "FK__Factura__Persona__2A4B4B5E",
                        column: x => x.Persona_Id,
                        principalTable: "Personas",
                        principalColumn: "Persona_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProductosFactura",
                columns: table => new
                {
                    Detalle_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalle_cantidad = table.Column<int>(nullable: true),
                    Detalle_iva = table.Column<double>(nullable: true),
                    Detalle_precio_unitario = table.Column<double>(nullable: true),
                    Detalle_precio_total = table.Column<double>(nullable: true),
                    Detalle_sub_total = table.Column<double>(nullable: true),
                    Factura_id = table.Column<int>(nullable: true),
                    Productos_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleP__CED7B6170E6E45D8", x => x.Detalle_id);
                    table.ForeignKey(
                        name: "FK__DetallePr__Factu__2D27B809",
                        column: x => x.Factura_id,
                        principalTable: "Factura",
                        principalColumn: "Factura_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DetallePr__Produ__2E1BDC42",
                        column: x => x.Productos_id,
                        principalTable: "Productos",
                        principalColumn: "Productos_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductosFactura_Factura_id",
                table: "DetalleProductosFactura",
                column: "Factura_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductosFactura_Productos_id",
                table: "DetalleProductosFactura",
                column: "Productos_id");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Persona_Id",
                table: "Factura",
                column: "Persona_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Categoria_id",
                table: "Productos",
                column: "Categoria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProductosFactura");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
