﻿// <auto-generated />
using System;
using LucyCalender.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LucyCalender.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("LucyCalender.Models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("backgroundColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("borderColor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("end")
                        .HasColumnType("TEXT");

                    b.Property<string>("eventColor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("start")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
