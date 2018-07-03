using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook: BaseGradeBook{
        public StandardGradeBook(string name,bool IsWeighted) 
            :base(name, IsWeighted)
        {
            this.Type = GradeBookType.Standard;
        }
    }
}