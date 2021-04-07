﻿// <auto-generated />
using System;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment1.Migrations
{
    [DbContext(typeof(SportingContext))]
    partial class SportingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment1.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "US"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Random Lane",
                            City = "Toronto",
                            CountryId = 1,
                            Email = "bruce@domain.com",
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            Phone = "416-123-6456",
                            PostalCode = "M4N 250",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "123 Random Lane",
                            City = "New York",
                            CountryId = 2,
                            Email = "janedoe@domain.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            Phone = "416-345-1237",
                            PostalCode = "1234",
                            State = "New York"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "123 Random Lane",
                            City = "Toronto",
                            CountryId = 1,
                            Email = "wats@domain.com",
                            FirstName = "Emily",
                            LastName = "Wats",
                            Phone = "647-860-1678",
                            PostalCode = "M4N 250",
                            State = "Ontario"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 2,
                            DateOpened = new DateTime(2021, 4, 6, 15, 44, 41, 950, DateTimeKind.Local).AddTicks(9857),
                            Description = "Customer is having issues with installation on Win 10",
                            ProductId = 1,
                            TechnicianId = 3,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 3,
                            DateOpened = new DateTime(2021, 4, 6, 15, 44, 41, 951, DateTimeKind.Local).AddTicks(523),
                            Description = "Encountered compatability issues",
                            ProductId = 2,
                            TechnicianId = 3,
                            Title = "Error launching program"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 1,
                            DateOpened = new DateTime(2021, 4, 6, 15, 44, 41, 951, DateTimeKind.Local).AddTicks(546),
                            Description = "Unknown error when attempting to open program",
                            ProductId = 1,
                            TechnicianId = 3,
                            Title = "Error while attempting to run program"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("YearlyPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "TRNY10",
                            Name = "Tournament Master",
                            ReleaseDate = new DateTime(2021, 4, 6, 15, 44, 41, 948, DateTimeKind.Local).AddTicks(2465),
                            YearlyPrice = 10.99
                        },
                        new
                        {
                            ProductId = 2,
                            Code = "DRAFT10",
                            Name = "Draft Manager 2.0",
                            ReleaseDate = new DateTime(2021, 4, 6, 15, 44, 41, 950, DateTimeKind.Local).AddTicks(6365),
                            YearlyPrice = 5.9900000000000002
                        },
                        new
                        {
                            ProductId = 3,
                            Code = "TRNY20",
                            Name = "Tournament Master 2.0",
                            ReleaseDate = new DateTime(2021, 4, 6, 15, 44, 41, 950, DateTimeKind.Local).AddTicks(6406),
                            YearlyPrice = 12.99
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "fGallager@sporting.com",
                            Name = "Fark Gallager",
                            Phone = "416-123-1234"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "tBurt@sporting.com",
                            Name = "Tim Burt",
                            Phone = "647-267-3795"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "ePoe@sporting.com",
                            Name = "Edgar Poe",
                            Phone = "437-769-1793"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Customer", b =>
                {
                    b.HasOne("Assignment1.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Assignment1.Models.Incident", b =>
                {
                    b.HasOne("Assignment1.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
