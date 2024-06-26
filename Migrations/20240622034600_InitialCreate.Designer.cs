﻿// <auto-generated />
using ContactManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManagement.Migrations
{
    [DbContext(typeof(ContactManagerDBContext))]
    [Migration("20240622034600_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactManagement.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Main St",
                            Email = "jane.doe@example.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 3,
                            Address = "123 Main St",
                            Email = "bob.doe@example.com",
                            FirstName = "Bob",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 4,
                            Address = "123 Main St",
                            Email = "alice.doe@example.com",
                            FirstName = "Alice",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 5,
                            Address = "123 Main St",
                            Email = "charlie.doe@example.com",
                            FirstName = "Charlie",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
