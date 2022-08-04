using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace k220Firstmvc.Models
{
    public partial class LibraryK310DBContext : DbContext
    {
        public LibraryK310DBContext()
        {
        }

        public LibraryK310DBContext(DbContextOptions<LibraryK310DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookToGenre> BookToGenres { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8QJDLB6;Initial Catalog=LibraryK310DB;Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.LanguageKey).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__AuthorId__286302EC");
            });

            modelBuilder.Entity<BookToGenre>(entity =>
            {
                entity.ToTable("Book_To_Genre");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookToGenres)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Book_To_G__BookI__2B3F6F97");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookToGenres)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Book_To_G__Genre__2C3393D0");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
