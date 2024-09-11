using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartMent> DepartMents { get; set; }

    public virtual DbSet<Empolyee> Empolyees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empolyee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TestPersons");

            entity.HasIndex(e => e.DepartId, "IX_TestPersons_DepartId");

            entity.HasOne(d => d.Depart).WithMany(p => p.Empolyees)
                .HasForeignKey(d => d.DepartId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TestPersons_DepartMents_DepartId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
