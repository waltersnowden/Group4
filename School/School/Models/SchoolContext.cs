using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School.Models
{
    public partial class SchoolContext : DbContext
    {
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.Classes).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject");
            });
        }
    }
}
