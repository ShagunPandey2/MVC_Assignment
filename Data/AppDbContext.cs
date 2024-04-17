using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Data
{

    public class AppDbContext(DbContextOptions<AppDbContext>options):DbContext(options)
    {
        

       // protected override void OnConfiguring
       //(DbContextOptionsBuilder optionsBuilder)
       // {
       //     optionsBuilder.UseInMemoryDatabase(databaseName: "StudentDb");
       // }


        public DbSet<Student> student { get; set; }
        public DbSet<StudentData.Models.Student> Students { get; set; } = default!;

public DbSet<StudentData.Models.StudentLogin> StudentLogin { get; set; } = default!;

public DbSet<StudentData.Models.url> url { get; set; } = default!;

    }
}
 
