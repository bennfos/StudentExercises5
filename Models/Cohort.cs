using System.Collections.Generic;

namespace StudentExercisesApp.Models
{
    // C# representation of the Employee table
    public class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        
       
    }
}