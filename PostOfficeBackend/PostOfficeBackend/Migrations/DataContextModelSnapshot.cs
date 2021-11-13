﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostOfficeBackend.DAL;

namespace PostOfficeBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PostOfficeBackend.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParcelLockerId")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ReceiverPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("char(12)")
                        .IsFixedLength(true);

                    b.Property<decimal>("WeightInKg")
                        .HasPrecision(6, 3)
                        .HasColumnType("decimal(6,3)");

                    b.HasKey("Id");

                    b.HasIndex("ParcelLockerId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("PostOfficeBackend.Models.ParcelLocker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<short>("MaxParcelsCount")
                        .HasColumnType("smallint");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("Id");

                    b.ToTable("ParcelLockers");
                });

            modelBuilder.Entity("PostOfficeBackend.Models.Parcel", b =>
                {
                    b.HasOne("PostOfficeBackend.Models.ParcelLocker", "ParcelLocker")
                        .WithMany()
                        .HasForeignKey("ParcelLockerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParcelLocker");
                });
#pragma warning restore 612, 618
        }
    }
}