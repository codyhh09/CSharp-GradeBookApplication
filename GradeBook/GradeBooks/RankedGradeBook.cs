using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name) 
            : base(name)
            {
                this.Type = GradeBookType.Ranked;
            }
        
        public override char GetLetterGrade(double averageGrade) {
            if(this.Students.Count < 5)
                throw new InvalidOperationException();
            var threshold = (int)Math.Ceiling(Students.Count * .2);
            var grades = this.Students
                                .OrderByDescending(x => x.AverageGrade)
                                .Select(x => x.AverageGrade)
                                .ToList();
            if(grades[threshold-1] <= averageGrade)
                return 'A';
            else if(grades[threshold*2-1] <= averageGrade)
                return 'B';
            else if(grades[threshold*3-1] <= averageGrade)
                return 'C';
            else if(grades[threshold*4-1] <= averageGrade)
                return 'D';
            else
                return 'F';
        } 
    }
}