namespace DrivingSchool.Interfaces
{
    public interface IValidation
    {
        bool CheckTitle(string title);
        bool CheckMark(int mark);
        bool CheckId(int id);
    }
}
