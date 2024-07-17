using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AfisolProject.Models;

public partial class ContactDbRaveenContext : DbContext
{
    public ContactDbRaveenContext()
    {
    }

    public ContactDbRaveenContext(DbContextOptions<ContactDbRaveenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ContactDB_Raveen;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__tblConta__5C6625BB832C14F9");

            entity.ToTable("tblContacts");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.TblContacts)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__tblContac__Count__3F466844");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__tblCount__10D160BF5A7253FF");

            entity.ToTable("tblCountries");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
