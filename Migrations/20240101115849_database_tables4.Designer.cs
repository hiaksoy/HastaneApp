﻿// <auto-generated />
using System;
using HastaneApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240101115849_database_tables4")]
    partial class database_tables4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HastaneApp.Entity.CalGun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CalismaGunleri");
                });

            modelBuilder.Entity("HastaneApp.Entity.CalSaat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CalismaSaatleri");
                });

            modelBuilder.Entity("HastaneApp.Entity.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CalGunId")
                        .HasColumnType("int");

                    b.Property<int>("CalSaatId")
                        .HasColumnType("int");

                    b.Property<int>("PoliId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalGunId");

                    b.HasIndex("CalSaatId");

                    b.HasIndex("PoliId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneApp.Entity.Gun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Gunler");
                });

            modelBuilder.Entity("HastaneApp.Entity.Poli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("HastaneApp.Entity.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("GunId")
                        .HasColumnType("int");

                    b.Property<int>("SaatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("GunId");

                    b.HasIndex("SaatId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("HastaneApp.Entity.Saat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Saatler");
                });

            modelBuilder.Entity("HastaneApp.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdSoyad")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Olusturmazamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("HastaneApp.Entity.Doktor", b =>
                {
                    b.HasOne("HastaneApp.Entity.CalGun", "CalGun")
                        .WithMany("Doktors")
                        .HasForeignKey("CalGunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneApp.Entity.CalSaat", "CalSaat")
                        .WithMany("Doktors")
                        .HasForeignKey("CalSaatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneApp.Entity.Poli", "Poli")
                        .WithMany("Doktors")
                        .HasForeignKey("PoliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalGun");

                    b.Navigation("CalSaat");

                    b.Navigation("Poli");
                });

            modelBuilder.Entity("HastaneApp.Entity.Randevu", b =>
                {
                    b.HasOne("HastaneApp.Entity.Doktor", "Doktor")
                        .WithMany("Randevus")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneApp.Entity.Gun", "Gun")
                        .WithMany("Randevus")
                        .HasForeignKey("GunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneApp.Entity.Saat", "Saat")
                        .WithMany("Randevus")
                        .HasForeignKey("SaatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Gun");

                    b.Navigation("Saat");
                });

            modelBuilder.Entity("HastaneApp.Entity.CalGun", b =>
                {
                    b.Navigation("Doktors");
                });

            modelBuilder.Entity("HastaneApp.Entity.CalSaat", b =>
                {
                    b.Navigation("Doktors");
                });

            modelBuilder.Entity("HastaneApp.Entity.Doktor", b =>
                {
                    b.Navigation("Randevus");
                });

            modelBuilder.Entity("HastaneApp.Entity.Gun", b =>
                {
                    b.Navigation("Randevus");
                });

            modelBuilder.Entity("HastaneApp.Entity.Poli", b =>
                {
                    b.Navigation("Doktors");
                });

            modelBuilder.Entity("HastaneApp.Entity.Saat", b =>
                {
                    b.Navigation("Randevus");
                });
#pragma warning restore 612, 618
        }
    }
}
