using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Courseplanner.Models
{
    public partial class SchoolContext : DbContext
    {
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudyPlans> StudyPlans { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PreviousCourse)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TopicArea).IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudyPlans>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.Property(e => e.PlanId)
                    .HasColumnName("PlanID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Papers)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudyPlans)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudyPlan__Stude__276EDEB3");
            });
        }
    }
}
