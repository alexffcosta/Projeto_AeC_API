﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apresentacao.Servicos;

namespace apresentacao.Migrations
{
    [DbContext(typeof(DbContexto))]
    partial class DbContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apresentacao.Models.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cidade");

                    b.Property<int>("Cpf")
                        .HasMaxLength(8)
                        .HasColumnType("int")
                        .HasColumnName("cpf");

                    b.Property<int>("Dtanascimento")
                        .HasMaxLength(8)
                        .HasColumnType("int")
                        .HasColumnName("dtnascimento");

                    b.Property<int>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("email");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("estado");

                    b.Property<string>("Estadocivil")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("estadocivil");

                    b.Property<string>("Logadouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("logadouro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Nomecontato")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("nomecontato");

                    b.Property<int>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<int>("ProfissaoId")
                        .HasColumnType("int")
                        .HasColumnName("id_profissao");

                    b.Property<int?>("VagaId")
                        .HasColumnType("int");

                    b.Property<int>("telcontato")
                        .HasMaxLength(12)
                        .HasColumnType("int")
                        .HasColumnName("telcontato");

                    b.HasKey("Id");

                    b.HasIndex("VagaId");

                    b.ToTable("candidatos");
                });

            modelBuilder.Entity("apresentacao.Models.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vaga_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cargo");

                    b.HasKey("Id");

                    b.ToTable("vagas");
                });

            modelBuilder.Entity("apresentacao.Models.Candidato", b =>
                {
                    b.HasOne("apresentacao.Models.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("VagaId");

                    b.Navigation("Vaga");
                });
#pragma warning restore 612, 618
        }
    }
}
