using Enrollment.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Datamodel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HGGKL34\\SQLEXPRESS;" +
                "Database=Entprog_Enrollment;Integrated Security=SSPI;"+
                "TrustServerCertificate=true"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("tblStudent");
            modelBuilder.Entity<Student>().Property(p => p.Lastname).HasColumnName("Surname");
            modelBuilder.Entity<Student>().Property(p => p.Firstname).HasColumnName("GivenName");
            modelBuilder.Entity<Student>().Property(p => p.Lastname).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>().Property(p => p.Firstname).HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                Lastname = "Ursua",
                Firstname = "Eruel",
            });


            modelBuilder.Entity<Subject>().Property(p => p.Code).HasColumnType("nvarchar(7)");
            modelBuilder.Entity<Subject>().Property(p => p.Description).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<Subject>().Property(p => p.Units).HasColumnType("decimal(18, 1)");
        }

        public DbSet <Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set;  }
        public DbSet<Subject> Subjects { get; set;  }
    }
}
