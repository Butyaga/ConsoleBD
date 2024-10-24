using System.Text.RegularExpressions;
using PTMK_Task.DAL;

namespace PTMK_Task.Model;
internal partial class Employee(string name, DateOnly birthDay, Sex sex)
{
    internal string Name { get; } = name;
    internal DateOnly BirthDay { get; } = birthDay;
    internal Sex Sex { get; } = sex;
    internal int Age
    {
        get
        {
            return GetAge(BirthDay);
        }
    }

    internal void SaveDB()
    {
        DBService.GetInstance.Save(this);
    }

    internal static bool IsValidAge(DateOnly birthDay)
    {
        int age = GetAge(birthDay);
        if (age < 15 || age > 99)
        {
            return false;
        }
        return true;
    }

    internal static bool IsValidName(string name)
    {
        return NameRegex().IsMatch(name);
    }

    #region Private
    [GeneratedRegex(@"^[A-Za-z ]{2,}$")]
    private static partial Regex NameRegex();

    private static int GetAge(DateOnly birthDay)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        int age = today.Year - birthDay.Year;
        if (birthDay > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }
    #endregion
}
