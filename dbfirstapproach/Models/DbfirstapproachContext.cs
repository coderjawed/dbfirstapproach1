using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbfirstapproach.Models;

public partial class DbfirstapproachContext : DbContext
{
    public DbfirstapproachContext()
    {
    }

    public DbfirstapproachContext(DbContextOptions<DbfirstapproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<Registera> Registeras { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Registera>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CompanyName).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Gstno)
                .HasMaxLength(20)
                .HasColumnName("GSTNo");
            entity.Property(e => e.MobileNo).HasMaxLength(15);
            entity.Property(e => e.RegisteredId).HasColumnName("RegisteredID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
