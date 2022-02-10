﻿// <auto-generated />
using System;
using DeslocamentoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeslocamentoApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Carro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Placa");

                    b.HasKey("Id");

                    b.ToTable("Carro", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Condutor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Condutor", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Deslocamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CarroId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("CondutorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DataHoraFim")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHoraFim");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHoraInicio");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasDefaultValue("Solicitacao de Deslocamento")
                        .HasColumnName("Observacao");

                    b.Property<decimal>("QuilometragemFinal")
                        .HasColumnType("decimal")
                        .HasColumnName("QuilometragemFinal");

                    b.Property<decimal>("QuilometragemInicial")
                        .HasColumnType("decimal")
                        .HasColumnName("QuilometragemInicial");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.ToTable("Deslocamento", (string)null);
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Deslocamento", b =>
                {
                    b.HasOne("DeslocamentoApp.Domain.Entities.Carro", "Carro")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deslocamento_Carro_CarroId");

                    b.HasOne("DeslocamentoApp.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deslocamento_Cliente_ClienteId");

                    b.HasOne("DeslocamentoApp.Domain.Entities.Condutor", "Condutor")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deslocamento_Condutor_CondutorId");

                    b.Navigation("Carro");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Carro", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("DeslocamentoApp.Domain.Entities.Condutor", b =>
                {
                    b.Navigation("Deslocamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
