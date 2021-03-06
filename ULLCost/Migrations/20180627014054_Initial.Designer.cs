﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using ULLCost.Models;

namespace ULLCost.Migrations
{
    [DbContext(typeof(ULLCostContext))]
    [Migration("20180627014054_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("ULLCost.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Credits");

                    b.Property<decimal>("Fees");

                    b.Property<string>("Level");

                    b.Property<string>("State");

                    b.Property<string>("Status");

                    b.Property<string>("Term");

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
