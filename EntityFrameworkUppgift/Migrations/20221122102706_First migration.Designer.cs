﻿// <auto-generated />
using EntityFrameworkUppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkUppgift.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221122102706_First migration")]
    partial class Firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityFrameworkUppgift.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Göteborg",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Stockholm",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Malmö",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 4,
                            CityName = "Helsinki",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 5,
                            CityName = "Copenhagen",
                            CountryId = 3
                        });
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Finland"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Denmark"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Norway"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Iceland"
                        });
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            Name = "Olof Olofsson",
                            PhoneNumber = "0733456021"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 2,
                            Name = "Per Persson",
                            PhoneNumber = "0733456022"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 3,
                            Name = "Anders Andersson",
                            PhoneNumber = "0733456023"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 4,
                            Name = "Rolf Rolfsson",
                            PhoneNumber = "0733456024"
                        },
                        new
                        {
                            PersonId = 5,
                            CityId = 5,
                            Name = "Björn Björnsson",
                            PhoneNumber = "0733456025"
                        });
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.City", b =>
                {
                    b.HasOne("EntityFrameworkUppgift.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.Person", b =>
                {
                    b.HasOne("EntityFrameworkUppgift.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("EntityFrameworkUppgift.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}