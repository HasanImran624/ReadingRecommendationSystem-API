using Koinz.Common;
using Koinz.DataProvider.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.DataProvider.EFCore.Context
{
    public partial class ReadingRecommendationBaseDBContext : DbContext
    {
        public ReadingRecommendationBaseDBContext()
        {
        }
        public ReadingRecommendationBaseDBContext(DbContextOptions<ReadingRecommendationBaseDBContext> options)
       : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReadingInterval> ReadingIntervals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(AppConfigrationManager.AppSettings["AnyhandyDatabase"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookName)
                    .HasMaxLength(255)
                    .HasColumnName("book_name");
            });

            modelBuilder.Entity<ReadingInterval>(entity =>
            {
                entity.HasKey(e => e.ReadingId)
                    .HasName("PRIMARY");

                entity.ToTable("reading_interval");

                entity.HasIndex(e => e.BookId, "book_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.ReadingId).HasColumnName("reading_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.EndPage).HasColumnName("end_page");

                entity.Property(e => e.StartPage).HasColumnName("start_page");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ReadingIntervals)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("reading_interval_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReadingIntervals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("reading_interval_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
