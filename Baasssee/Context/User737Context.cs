using System;
using System.Collections.Generic;
using Baasssee.Models;
using Microsoft.EntityFrameworkCore;

namespace Baasssee.Context;

public partial class User737Context : DbContext
{
    public User737Context()
    {
    }

    public User737Context(DbContextOptions<User737Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Tagofclient> Tagofclients { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<Visitofclient> Visitofclients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.159;Database=user737;Username=user737;password=71876");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pk");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Photopath)
                .HasColumnType("character varying")
                .HasColumnName("photopath");
            entity.Property(e => e.Registationdate).HasColumnName("registationdate");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("client_genders_fk");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ClientId }).HasName("document_pk");

            entity.ToTable("document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Path).HasColumnName("path");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("gender_pk");

            entity.ToTable("genders");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Namegender)
                .HasColumnType("character varying")
                .HasColumnName("namegender");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.InverseCodeNavigation)
                .HasForeignKey<Gender>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genders_genders_fk");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pk");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(1)
                .HasColumnName("color");
            entity.Property(e => e.Title)
                .HasMaxLength(1)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Tagofclient>(entity =>
        {
            entity.HasKey(e => new { e.Clientid, e.Tagid }).HasName("tagofclient_pk");

            entity.ToTable("tagofclient");

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Tagid).HasColumnName("tagid");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("visit");

            entity.HasIndex(e => e.Id, "visit_unique").IsUnique();

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<Visitofclient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("visitofclient");

            entity.HasIndex(e => new { e.ClientId, e.VisitId }, "visitofclient_unique").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.VisitId).HasColumnName("visit_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
