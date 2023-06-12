using System.Linq;
using DrivingSchool.Interfaces;

namespace DrivingSchool.Services
{
    public class Validation : IValidation
    {
        protected IDrivingSchoolDbContext _context;

        public Validation(IDrivingSchoolDbContext context)
        {
            _context = context;
        }

        public bool CheckTitle(string title)
        {
            return title != "theory" && title != "driving";
        }

        public bool CheckMark(int mark)
        {
            return mark is > 0 and <= 10;
        }

        public bool CheckId(int id)
        {
            return _context.Students.Any(x => x.Id == id);
        }
    }
}
