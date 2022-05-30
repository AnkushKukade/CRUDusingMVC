using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDusingMVC.Models
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options): base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Skills)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("money");

                entity.Property(e => e.AddedOn)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            });
        }
    }
}
