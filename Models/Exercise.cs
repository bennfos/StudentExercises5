using System.Collections.Generic;

namespace StudentExercisesApp.Models
{
    // C# representation of the Employee table
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Student> students { get; set; } = new List<Student>();
     
    }
}