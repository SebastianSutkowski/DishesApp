﻿// <auto-generated />
using DishesApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DishesApp.Migrations
{
    [DbContext(typeof(DishesAppDbContext))]
    [Migration("20230509182541_DishConfiguration")]
    partial class DishConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DishesApp.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreparingMethodId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("TimeNeaded")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreparingMethodId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("DishesApp.Entities.ManyManyConnectors.ProductDish", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDish");
                });

            modelBuilder.Entity("DishesApp.Entities.ManyManyConnectors.TagDish", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TagDish");
                });

            modelBuilder.Entity("DishesApp.Entities.MeasurmentUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MeasurmentUnits");
                });

            modelBuilder.Entity("DishesApp.Entities.PreparingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PreparingMethods");
                });

            modelBuilder.Entity("DishesApp.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MeasurmentUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("MeasurmentUnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DishesApp.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DishId")
                        .IsUnique();

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("DishesApp.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DishesApp.Entities.Dish", b =>
                {
                    b.HasOne("DishesApp.Entities.PreparingMethod", "PreparingMethod")
                        .WithMany("Dishes")
                        .HasForeignKey("PreparingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreparingMethod");
                });

            modelBuilder.Entity("DishesApp.Entities.ManyManyConnectors.ProductDish", b =>
                {
                    b.HasOne("DishesApp.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishesApp.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DishesApp.Entities.ManyManyConnectors.TagDish", b =>
                {
                    b.HasOne("DishesApp.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishesApp.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DishesApp.Entities.Product", b =>
                {
                    b.HasOne("DishesApp.Entities.MeasurmentUnit", "MeasurmentUnit")
                        .WithMany("Products")
                        .HasForeignKey("MeasurmentUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurmentUnit");
                });

            modelBuilder.Entity("DishesApp.Entities.Recipe", b =>
                {
                    b.HasOne("DishesApp.Entities.Dish", "Dish")
                        .WithOne("Recipe")
                        .HasForeignKey("DishesApp.Entities.Recipe", "DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("DishesApp.Entities.Dish", b =>
                {
                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DishesApp.Entities.MeasurmentUnit", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DishesApp.Entities.PreparingMethod", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
