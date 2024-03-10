﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrainingApp;

#nullable disable

namespace TrainingApp.Migrations
{
    [DbContext(typeof(TrainingAppContext))]
    [Migration("20240306212841_userChange")]
    partial class userChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TrainingApp.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("exercise");
                });

            modelBuilder.Entity("TrainingApp.Model.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("MuscleGroup");
                });

            modelBuilder.Entity("TrainingApp.Model.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Reps")
                        .HasColumnType("integer")
                        .HasColumnName("reps");

                    b.Property<DateTime?>("SerieEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("serie_end");

                    b.Property<DateTime>("SerieStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("serie_start");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("serie");
                });

            modelBuilder.Entity("TrainingApp.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("TrainingApp.Model.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("WorkoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("workoutEnd");

                    b.Property<DateTime>("WorkoutStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("workoutStart");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("workout");
                });

            modelBuilder.Entity("TrainingApp.Model.MuscleGroup", b =>
                {
                    b.HasOne("TrainingApp.Model.Exercise", null)
                        .WithMany("MuscleGroups")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("TrainingApp.Model.Serie", b =>
                {
                    b.HasOne("TrainingApp.Model.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingApp.Model.Workout", null)
                        .WithMany("Series")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("TrainingApp.Model.Workout", b =>
                {
                    b.HasOne("TrainingApp.Model.User", null)
                        .WithMany("Trainings")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("TrainingApp.Model.Exercise", b =>
                {
                    b.Navigation("MuscleGroups");
                });

            modelBuilder.Entity("TrainingApp.Model.User", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("TrainingApp.Model.Workout", b =>
                {
                    b.Navigation("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
