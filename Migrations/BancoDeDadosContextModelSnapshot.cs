﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViagemBella.Models;

namespace ViagemBella.Migrations
{
    [DbContext(typeof(BancoDeDadosContext))]
    partial class BancoDeDadosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ViagemBella.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ViagemBella.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("FK_IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("FK_IdPacote")
                        .HasColumnType("int");

                    b.Property<int?>("PacoteIdPacote")
                        .HasColumnType("int");

                    b.Property<string>("data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCompra");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("PacoteIdPacote");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ViagemBella.Models.Pacote", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diarias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPacote");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("ViagemBella.Models.Compra", b =>
                {
                    b.HasOne("ViagemBella.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("ViagemBella.Models.Pacote", "Pacote")
                        .WithMany()
                        .HasForeignKey("PacoteIdPacote");

                    b.Navigation("Cliente");

                    b.Navigation("Pacote");
                });
#pragma warning restore 612, 618
        }
    }
}