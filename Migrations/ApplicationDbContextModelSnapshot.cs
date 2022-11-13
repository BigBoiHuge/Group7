﻿// <auto-generated />
using System;
using HappyCitizens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HappyCitizens.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("HappyCitizens.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeputyAppraiser")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MailingAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhysicalAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("HappyCitizens.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HappyCitizens.Models.Property", b =>
                {
                    b.HasOne("HappyCitizens.Models.User", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HappyCitizens.Models.User", b =>
                {
                    b.HasOne("HappyCitizens.Models.User", null)
                        .WithMany("SharedProfiles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HappyCitizens.Models.User", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("SharedProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
