﻿// <auto-generated />
using System;
using JuliePro_DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JuliePro_DataAccess.Migrations
{
    [DbContext(typeof(JulieProDbContext))]
    [Migration("20221116184926_AddLimitsToRecordAmount")]
    partial class AddLimitsToRecordAmount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JuliePro_DataModels.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CertificationCenter")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("JuliePro_DataModels.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Parent_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Parent_Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("JuliePro_DataModels.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discipline_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Trainer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Discipline_Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("JuliePro_DataModels.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discipline_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Photo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("Discipline_Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("JuliePro_DataModels.TrainerCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Certification_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCertification")
                        .HasColumnType("datetime2");

                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Certification_Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("TrainerCertifications");
                });

            modelBuilder.Entity("JuliePro_DataModels.Discipline", b =>
                {
                    b.HasOne("JuliePro_DataModels.Discipline", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("Parent_Id");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("JuliePro_DataModels.Record", b =>
                {
                    b.HasOne("JuliePro_DataModels.Discipline", "Discipline")
                        .WithMany("TrainerPersonalRecords")
                        .HasForeignKey("Discipline_Id");

                    b.HasOne("JuliePro_DataModels.Trainer", "Trainer")
                        .WithMany("Records")
                        .HasForeignKey("Trainer_Id");

                    b.Navigation("Discipline");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro_DataModels.Trainer", b =>
                {
                    b.HasOne("JuliePro_DataModels.Discipline", "Discipline")
                        .WithMany("Trainers")
                        .HasForeignKey("Discipline_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("JuliePro_DataModels.TrainerCertification", b =>
                {
                    b.HasOne("JuliePro_DataModels.Certification", "Certification")
                        .WithMany("TrainerCertification")
                        .HasForeignKey("Certification_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuliePro_DataModels.Trainer", "Trainer")
                        .WithMany("TrainerCertification")
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certification");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro_DataModels.Certification", b =>
                {
                    b.Navigation("TrainerCertification");
                });

            modelBuilder.Entity("JuliePro_DataModels.Discipline", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("TrainerPersonalRecords");

                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("JuliePro_DataModels.Trainer", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("TrainerCertification");
                });
#pragma warning restore 612, 618
        }
    }
}
