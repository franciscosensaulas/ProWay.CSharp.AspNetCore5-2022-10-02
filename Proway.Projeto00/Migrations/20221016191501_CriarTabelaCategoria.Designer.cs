﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proway.Projeto00.Database;

#nullable disable

namespace Proway.Projeto00.Migrations
{
    [DbContext(typeof(ProjetoContext))]
    [Migration("20221016191501_CriarTabelaCategoria")]
    partial class CriarTabelaCategoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proway.Projeto00.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("categorias", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Ação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Romance"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Programação"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
