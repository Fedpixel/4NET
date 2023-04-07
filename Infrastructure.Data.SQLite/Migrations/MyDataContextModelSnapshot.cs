﻿// <auto-generated />
using System;
using Infrastructure.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.SQLite.Migrations
{
    [DbContext(typeof(MyDataContext))]
    partial class MyDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("Domain.Annonces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Energie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NombreCV")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NombreKm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("T_Annonces", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
