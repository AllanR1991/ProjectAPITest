﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPITest.Context;

#nullable disable

namespace ProjectAPITest.Migrations
{
    [DbContext(typeof(ProjectApiContextContext))]
    [Migration("20240806120529_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectAPITest.Domains.Products", b =>
                {
                    b.Property<Guid>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProduct");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            IdProduct = new Guid("2609c286-be91-495e-bd78-109a8b7ea8d4"),
                            Name = "Samsung A52s",
                            Price = 2768.90m
                        },
                        new
                        {
                            IdProduct = new Guid("a5da2aff-0092-4c52-8202-5ffacec20d12"),
                            Name = "Apple iPhone 15 Pro Max 512 GB -Titânio Natural",
                            Price = 9699m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
