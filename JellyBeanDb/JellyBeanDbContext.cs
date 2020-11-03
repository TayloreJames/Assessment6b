using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Assessment6b.Models;

namespace Assessment6b.JellyBeanDb
{
    public partial class JellyBeanDbContext : DbContext
    {
        public JellyBeanDbContext()
        {
        }

        public JellyBeanDbContext(DbContextOptions<JellyBeanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JellyBean> JellyBean { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=JellyBeanDb;User=sa;Password=AnExamplePassword1@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JellyBean>(entity =>
            {
                entity.Property(e => e.Style).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
