using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IV.DataCenter.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BtStkType> BtStkTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=IVMGMT;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BtStkType>(entity =>
        {
            entity.HasKey(e => e.StkTypeId);

            entity.ToTable("BT_STK_TYPE");

            entity.Property(e => e.StkTypeId).HasColumnName("STK_TYPE_ID");
            entity.Property(e => e.StkTypeDesc)
                .HasMaxLength(200)
                .HasColumnName("STK_TYPE_DESC");
            entity.Property(e => e.StkTypeName)
                .HasMaxLength(30)
                .HasColumnName("STK_TYPE_NAME");
            entity.Property(e => e.TimeLog)
                .HasColumnType("datetime")
                .HasColumnName("TIME_LOG");
            entity.Property(e => e.UserLog)
                .HasMaxLength(20)
                .HasColumnName("USER_LOG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
