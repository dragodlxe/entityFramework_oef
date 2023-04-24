﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oefproject;

#nullable disable

namespace oefproject.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("oefproject.models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weignt")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"),
                            Name = "Pending tasks",
                            Weignt = 20
                        },
                        new
                        {
                            CategoryId = new Guid("f53b5019-1a13-489d-86bb-28160188dbd9"),
                            Name = "Personal tasks",
                            Weignt = 50
                        });
                });

            modelBuilder.Entity("oefproject.models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskPriority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("f2c40001-6c9a-43a4-aeb3-cc7902499e2e"),
                            CategoryId = new Guid("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"),
                            CreateDt = new DateTime(2023, 4, 23, 13, 32, 36, 446, DateTimeKind.Local).AddTicks(1907),
                            TaskPriority = "Mid",
                            Title = "Payment due public services"
                        },
                        new
                        {
                            TaskId = new Guid("cd12ffd5-c35c-45a6-ba43-013d2402b498"),
                            CategoryId = new Guid("f53b5019-1a13-489d-86bb-28160188dbd9"),
                            CreateDt = new DateTime(2023, 4, 23, 13, 32, 36, 446, DateTimeKind.Local).AddTicks(1923),
                            TaskPriority = "Low",
                            Title = "Finish movie on netflix"
                        });
                });

            modelBuilder.Entity("oefproject.models.Task", b =>
                {
                    b.HasOne("oefproject.models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("oefproject.models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}