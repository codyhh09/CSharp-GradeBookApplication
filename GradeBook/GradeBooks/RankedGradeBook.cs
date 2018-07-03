using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) 
            : base(name, IsWeighted)
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

        public override void CalculateStatistics(){
            if(this.Students.Count < 5){
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();    
        }

        public override void CalculateStudentStatistics(string name){
            if(this.Students.Count < 5){
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }            base.CalculateStudentStatistics(name);    
        }
    }
}