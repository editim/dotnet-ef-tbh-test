﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TestApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221130083118_AddTaskC")]
    partial class AddTaskC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("task_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasDiscriminator<string>("task_type").HasValue("TaskBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TaskA", b =>
                {
                    b.HasBaseType("TaskBase");

                    b.Property<int>("RandomProp")
                        .HasColumnType("int");

                    b.Property<int>("TaskAProp")
                        .HasColumnType("int");

                    b.ToTable(t =>
                        {
                            t.Property("RandomProp")
                                .HasColumnName("TaskA_RandomProp");
                        });

                    b.HasDiscriminator().HasValue("a");
                });

            modelBuilder.Entity("TaskB", b =>
                {
                    b.HasBaseType("TaskBase");

                    b.Property<int>("RandomProp")
                        .HasColumnType("int");

                    b.Property<int>("TaskBProp")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("b");
                });

            modelBuilder.Entity("TaskC", b =>
                {
                    b.HasBaseType("TaskBase");

                    b.Property<int>("RandomProp")
                        .HasColumnType("int");

                    b.Property<int>("RandomProp2")
                        .HasColumnType("int");

                    b.Property<int>("TaskCProp")
                        .HasColumnType("int");

                    b.ToTable(t =>
                        {
                            t.Property("RandomProp")
                                .HasColumnName("TaskC_RandomProp");
                        });

                    b.HasDiscriminator().HasValue("c");
                });
#pragma warning restore 612, 618
        }
    }
}