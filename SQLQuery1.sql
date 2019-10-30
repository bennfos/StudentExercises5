﻿CREATE TABLE Student_Exercises (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	StudentId INTEGER NOT NULL,
	ExerciseId INTEGER NOT NULL,
	CONSTRAINT FK_STUDENT_EXERCISE FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id),
	CONSTRAINT FK_EXERCISE_STUDENT FOREIGN KEY(StudentId) REFERENCES Student(Id),
) 