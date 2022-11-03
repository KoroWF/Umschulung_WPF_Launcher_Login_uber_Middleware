﻿// <auto-generated />
using BenutzerService.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenutzerService.Migrations
{
    [DbContext(typeof(DatenbankContext))]
    [Migration("20221026070926_AdminAnlegen")]
    partial class AdminAnlegen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Model.Nutzer", b =>
                {
                    b.Property<int>("nutzerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("NUTZER_ID");

                    b.Property<string>("name")
                        .HasMaxLength(70)
                        .HasColumnType("TEXT")
                        .HasColumnName("NAME");

                    b.Property<string>("pwd")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("PWD");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("UID");

                    b.Property<string>("vorname")
                        .HasMaxLength(70)
                        .HasColumnType("TEXT")
                        .HasColumnName("VORNAME");

                    b.HasKey("nutzerId");

                    b.ToTable("NUTZER");
                });
#pragma warning restore 612, 618
        }
    }
}
