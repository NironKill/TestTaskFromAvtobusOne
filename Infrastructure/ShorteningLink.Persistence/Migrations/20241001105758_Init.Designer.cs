﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShorteningLink.Persistence;

#nullable disable

namespace ShorteningLink.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241001105758_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShorteningLink.Domain.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LongURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ShortURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VisitCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Link");
                });
#pragma warning restore 612, 618
        }
    }
}