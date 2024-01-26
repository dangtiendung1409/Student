using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Test.Models;

namespace Test.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentContext(
                serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>()))
            {
                // Look for any students.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        Group = "GroupA",
                        RollNumber = "A001",
                        Fullname = "John Doe",
                        Absent = true,   
                        Present = false, 
                        Comment = "Good student",
                        Image = "john_doe.jpg"
                    },
                    new Student
                    {
                        Group = "GroupB",
                        RollNumber = "B001",
                        Fullname = "Jane Doe",
                        Absent = false,  
                        Present = true,  
                        Comment = "Excellent student",
                        Image = "jane_doe.jpg"
                    }
                // Add more students as needed
                );

                context.SaveChanges();
            }
        }
    }
}
