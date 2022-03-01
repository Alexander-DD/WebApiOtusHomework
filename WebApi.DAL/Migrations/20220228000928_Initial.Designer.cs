﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.DAL;

namespace WebApi.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220228000928_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebApi.DAL.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("lastname");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
