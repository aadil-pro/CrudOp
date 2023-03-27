using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Entities;

public partial class CrudDbContext : DbContext
{
    public CrudDbContext()
    {
    }

    public CrudDbContext(DbContextOptions<CrudDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SendMoney> SendMoneys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AADIL\\SQLEXPRESS;Initial Catalog=CrudOp;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SendMoney>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SendMone__3214EC278F2C06BB");

            entity.ToTable("SendMoney");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AmountReceived).HasColumnType("money");
            entity.Property(e => e.AmountToSend).HasColumnType("money");
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
