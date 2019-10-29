namespace StudentExercisesApp.Models
{
    // C# representation of the Employee table
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public string SlackHandle { get; set; }

        public string Specialty { get; set; }

        public int CohortId { get; set; }

        // This property is for storing the C# object representing the department
        public Cohort Cohort { get; set; }
    }
}