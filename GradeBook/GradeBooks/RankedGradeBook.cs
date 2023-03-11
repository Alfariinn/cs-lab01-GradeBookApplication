using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            double studentCount = Students.Count;
            int topStudents = 0;

            if (studentCount < 5)
            {
                throw new ArgumentException("Ranked grading requires at least 5 students.");
            }
            else
            {
                studentCount = studentCount / 5;

                foreach (Student student in Students)
                    foreach (double grade in student.Grades)
                        if (grade > averageGrade)
                            topStudents++;
            }
            double percentage = topStudents / studentCount;
            if (percentage < 1) return 'A';
            else if (percentage < 2) return 'B';
            else if (percentage < 3) return 'C';
            else if (percentage < 4) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            double studentCount = Students.Count;
            if (studentCount < 5) 
                { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else 
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            double studentCount = Students.Count;
            if (studentCount < 5)
            { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else
            base.CalculateStudentStatistics(name);
        }
    }
}