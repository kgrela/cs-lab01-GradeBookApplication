using System;
using System.Collections.Generic;
using System.Text;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool enable) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw InvalidOperationException;
            }

            int sortStudent = 0;

            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    sortStudent++;
                }
            }

            if (sortStudent < Students.Count / 5)
            {
                return 'A';
            }
            else if (sortStudent < 2 * (Students.Count / 5))
            {
                return 'B';
            }
            else if (sortStudent < 3 * (Students.Count / 5))
            {
                return 'C';
            }
            else if (sortStudent < 4 * (Students.Count / 5))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students!");
            }
            else
            {
                base.CalculateStatistics();
            }

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students!");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }

        }

        public Exception InvalidOperationException { get; set; }
    }
}
