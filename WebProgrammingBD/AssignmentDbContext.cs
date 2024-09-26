using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgrammingBD
{
    public class AssignmentDbContext : DbContext
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<CompletionRecord> CompletionRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=192.168.200.13;user=student;password=student;database=WebProgrammingDB;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }

    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }
    }

    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<CompletionRecord> CompletionRecords { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompletionRecord> CompletionRecords { get; set; }
    }

    public class Requirement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }

    public class CompletionRecord
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool IsCompleted { get; set; }
        public string Comments { get; set; }
    }
}
