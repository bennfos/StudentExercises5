using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercisesApp.Models;

namespace StudentExercisesApp.Data
{
   
    public class Repository
    {
       
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }


       
        public List<Exercise> GetAllExercises()
        {
            
            using (SqlConnection conn = Connection)
            {
                
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    
                    cmd.CommandText = "SELECT * FROM Exercise";
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    
                    List<Exercise> exercises = new List<Exercise>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        //  For our query, "Id" has an ordinal value of 0 and "DeptName" is 1.
                        int idColumnPosition = reader.GetOrdinal("Id");

                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseTitleColumnPosition = reader.GetOrdinal("Title");
                        string exerciseTitleValue = reader.GetString(exerciseTitleColumnPosition);

                        // Now let's create a new object using the data from the database.
                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Title = exerciseTitleValue
                        };

                        // ...and add that department object to our list.
                        exercises.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return exercises;
                }
            }
        }

        public void AddExercises(Exercise exercise)
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "INSERT INTO Exercise (Title) VALUES (@title)";
                    cmd.Parameters.Add(new SqlParameter("@title", exercise.Title));


                    cmd.ExecuteNonQuery();
                                                                              
                }
            }
        }

        public List<Instructor> GetAllInstructorsWithCohort()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT i.Id, i.FirstName, i.LastName, i.SlackHandle, i.Specialty, i.CohortId,
                                               c.Name
                                          FROM Instructor i LEFT JOIN Cohort c ON i.CohortId = c.Id";

                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructorsWithCohort = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Specialty = reader.GetString(reader.GetOrdinal("Specialty")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            }
                        };

                        instructorsWithCohort.Add(instructor);
                    }

                    reader.Close();

                    return instructorsWithCohort;



                }
            }
        }


        public void AddInstructor(Instructor instructor)
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) VALUES (@firstName, @lastName, @slackHandle, @specialty, @cohortId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slackHandle", instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@specialty", instructor.Specialty));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", instructor.CohortId));
                    


                    cmd.ExecuteNonQuery();

                }
            }
        }


    }
}