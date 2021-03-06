﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YesDay.Models.Entities
{
    public partial class YesDayContext : DbContext
    {
        public YesDayContext()
        {
        }

        public YesDayContext(DbContextOptions<YesDayContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YesDayLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.EstimatedCost).HasColumnType("money");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Userref)
                    .IsRequired()
                    .HasMaxLength(450);

            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Guest__A9D10534BF7D6C01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FoodPreference).HasMaxLength(50);

                entity.Property(e => e.GuestNote).HasMaxLength(100);

                entity.Property(e => e.GuestTitle).HasMaxLength(50);

                entity.Property(e => e.InvitedBy).HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rsvp)
                    .HasColumnName("RSVP")
                    .HasMaxLength(50);

                entity.Property(e => e.Userref)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.WeddingCrewTitle).HasMaxLength(50);

            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TaskNote).HasMaxLength(250);

                entity.Property(e => e.TaskStatus).HasMaxLength(50);

                entity.Property(e => e.Userref)
                    .IsRequired()
                    .HasMaxLength(450);

            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactInfo).HasMaxLength(100);

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Userref)
                    .IsRequired()
                    .HasMaxLength(450);

            });
        }
    }
}
