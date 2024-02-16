﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutriCare.Models;

#nullable disable

namespace NutriCare.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221212155209_ScanHistoryRelation")]
    partial class ScanHistoryRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NutriCare.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<int?>("AllergiesAllergyId")
                        .HasColumnType("int");

                    b.Property<int?>("DiabetesId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IntoleranceId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Password")
                        .HasColumnType("tinyint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("AllergiesAllergyId");

                    b.HasIndex("DiabetesId");

                    b.HasIndex("IntoleranceId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("NutriCare.Models.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergyId");

                    b.ToTable("Allergy");
                });

            modelBuilder.Entity("NutriCare.Models.Diabetes", b =>
                {
                    b.Property<int>("DiabetesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiabetesId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiabetesId");

                    b.ToTable("Diabetes");
                });

            modelBuilder.Entity("NutriCare.Models.Intolerance", b =>
                {
                    b.Property<int>("IntoleranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IntoleranceId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntoleranceId");

                    b.ToTable("Intolerance");
                });

            modelBuilder.Entity("NutriCare.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("NutriCare.Models.ScanHistory", b =>
                {
                    b.Property<int>("ScanHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScanHistoryId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScanTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ScanHistoryId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ProductId");

                    b.ToTable("ScanHistories");
                });

            modelBuilder.Entity("NutriCare.Models.Account", b =>
                {
                    b.HasOne("NutriCare.Models.Allergy", "Allergies")
                        .WithMany()
                        .HasForeignKey("AllergiesAllergyId");

                    b.HasOne("NutriCare.Models.Diabetes", "Diabetes")
                        .WithMany()
                        .HasForeignKey("DiabetesId");

                    b.HasOne("NutriCare.Models.Intolerance", "Intolerance")
                        .WithMany()
                        .HasForeignKey("IntoleranceId");

                    b.Navigation("Allergies");

                    b.Navigation("Diabetes");

                    b.Navigation("Intolerance");
                });

            modelBuilder.Entity("NutriCare.Models.ScanHistory", b =>
                {
                    b.HasOne("NutriCare.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriCare.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}