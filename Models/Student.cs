using System.Collections.Generic;

namespace StudentExercisesApp.Models
{
    // C# representation of the Employee table
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //T his is to hold the actual foreign key integer
        public string SlackHandle { get; set; }

        // This property is for storing the C# object representing the department
        public int CohortId { get; set; }

        public Cohort Cohort { get; set; }

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

    }
}