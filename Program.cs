using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercisesApp.Data;
using StudentExercisesApp.Models;


namespace StudentExercisesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();

            Console.WriteLine("All Exercises");
            Console.WriteLine("-------------");
            foreach (Exercise exercise in exercises) 
            {
                Console.WriteLine(exercise.Title);
            }

            Pause();

            Exercise nutshell = new Exercise()
            {
                Title = "Nutshell"
            };

            repository.AddExercises(nutshell);

            exercises = repository.GetAllExercises();

            Console.WriteLine("All Exercises after adding Nutshell");
            Console.WriteLine("-------------");
            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine(exercise.Title);
            }

            Pause();

            List<Instructor> instructorsWithCohort = repository.GetAllInstructorsWithCohort();

            Console.WriteLine("All Instructors with Cohort");
            Console.WriteLine("-------------");
            foreach (Instructor instructor in instructorsWithCohort)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName} is in {instructor.Cohort.Name}");
            }

            Pause();

            Instructor newInstructor = new Instructor()
            {
                FirstName = "Jisie",
                LastName = "David",
                SlackHandle = "jdavid",
                Specialty = "JS",
                CohortId = 2
            };

            repository.AddInstructor(newInstructor);

            Console.WriteLine("All Instructors with Cohort after adding Jisie");
            Console.WriteLine("-------------");
            foreach (Instructor instructor in instructorsWithCohort)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName} is in {instructor.Cohort.Name}");
            }


        }
          public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
