﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thinktecture.TestDatabaseContext;

namespace Thinktecture.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Thinktecture.TestDatabaseContext.TestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Name");

                    b.Property<int>("PropertyWithBackingField");

                    b.Property<string>("ShadowProperty")
                        .HasMaxLength(50);

                    b.Property<int>("_privateField");

                    b.HasKey("Id");

                    b.ToTable("TestEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
