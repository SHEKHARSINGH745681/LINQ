using LINQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Sample student data
        private static readonly IList<Student> studentList = new List<Student>()
        {
            new Student() { StudentID = 1, StudentName = "shekhar", Age = 25 },
            new Student() { StudentID = 2, StudentName = "pradeep", Age = 24 },
            new Student() { StudentID = 3, StudentName = "nihal", Age = 18 },
            new Student() { StudentID = 4, StudentName = "Ram", Age = 24 },
            new Student() { StudentID = 5, StudentName = "shyam", Age = 25 }
        };

        [HttpGet("grouped")]
        public IActionResult GetGroupedStudents()
        {
            var groupedResult = studentList.GroupBy(s => s.Age)
                                            .Select(g => new
                                            {
                                                AgeGroup = g.Key,
                                                Students = g.Select(s => s.StudentName).ToList()
                                            });

            return Ok(groupedResult);
        }
    }
}