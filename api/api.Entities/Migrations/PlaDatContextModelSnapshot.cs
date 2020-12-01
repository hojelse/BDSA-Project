﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Entities;

namespace api.Entities.Migrations
{
    [DbContext(typeof(PlaDatContext))]
    partial class PlaDatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CapabilityPlacement", b =>
                {
                    b.Property<int>("CapabilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("PlacementsId")
                        .HasColumnType("int");

                    b.HasKey("CapabilitiesId", "PlacementsId");

                    b.HasIndex("PlacementsId");

                    b.ToTable("CapabilityPlacement");
                });

            modelBuilder.Entity("CapabilityStudent", b =>
                {
                    b.Property<int>("CapabilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CapabilitiesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CapabilityStudent");
                });

            modelBuilder.Entity("api.Entities.Capability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Capabilities");
                });

            modelBuilder.Entity("api.Entities.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("api.Entities.Placement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EmployerCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("PlacementImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployerCompanyId");

                    b.ToTable("Placements");
                });

            modelBuilder.Entity("api.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PlacementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlacementId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("api.Entities.StudentPlacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PlacementId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlacementId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentPlacement");
                });

            modelBuilder.Entity("CapabilityPlacement", b =>
                {
                    b.HasOne("api.Entities.Capability", null)
                        .WithMany()
                        .HasForeignKey("CapabilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Entities.Placement", null)
                        .WithMany()
                        .HasForeignKey("PlacementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CapabilityStudent", b =>
                {
                    b.HasOne("api.Entities.Capability", null)
                        .WithMany()
                        .HasForeignKey("CapabilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Entities.Placement", b =>
                {
                    b.HasOne("api.Entities.Employer", "EmployerCompany")
                        .WithMany()
                        .HasForeignKey("EmployerCompanyId");

                    b.Navigation("EmployerCompany");
                });

            modelBuilder.Entity("api.Entities.Student", b =>
                {
                    b.HasOne("api.Entities.Placement", null)
                        .WithMany("Applicants")
                        .HasForeignKey("PlacementId");
                });

            modelBuilder.Entity("api.Entities.StudentPlacement", b =>
                {
                    b.HasOne("api.Entities.Placement", "Placement")
                        .WithMany()
                        .HasForeignKey("PlacementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Entities.Student", "Student")
                        .WithMany("Placements")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Placement");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("api.Entities.Placement", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("api.Entities.Student", b =>
                {
                    b.Navigation("Placements");
                });
#pragma warning restore 612, 618
        }
    }
}
