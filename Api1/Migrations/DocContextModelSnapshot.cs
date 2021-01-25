﻿// <auto-generated />
using System;
using Api1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api1.Migrations
{
    [DbContext(typeof(DocContext))]
    partial class DocContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Api1.Models.Doc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("Api1.Models.Version", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Release")
                        .HasColumnType("int");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UploadDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DocId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("Api1.Models.Version", b =>
                {
                    b.HasOne("Api1.Models.Doc", "Doc")
                        .WithMany("Versions")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doc");
                });

            modelBuilder.Entity("Api1.Models.Doc", b =>
                {
                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
