using Abstract;
using PTMK_Task.Model;

namespace PTMK_Task.DAL;
internal static class ModelFactory
{
    internal static Employee CreateEmployee(string[]? args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != 3)
        {
            throw new ArgumentException("Переданые данные сотрудника недостаточны");
        }

        string name = GetName(args[0]);
        DateOnly date = GetDate(args[1]);
        Sex sex = GetSex(args[2]);

        return new(name, date, sex);
    }

    internal static List<Employee> CreateEmployee(IEnumerable<IEmployee> list)
    {
        var coll = from IEmployee item in list select new Employee(item.Name, item.BirthDay, (Sex)item.Sex);
        return coll.ToList();
    }

    internal static List<Employee> GetRamdomEmployees(int count)
    {
        Random rand = new();
        List<Employee> employees = [];
        int name1Count = _name1.Length;
        int name2Count = _name2.Length;
        int name3Count = _name3.Length;

        for (int i = 0; i < count; i++)
        {
            string name = _name1[rand.Next(name1Count)] + " " + _name2[rand.Next(name2Count)] + " " + _name3[rand.Next(name3Count)];
            DateOnly date = new(rand.Next(1970, 2005), rand.Next(1, 13), rand.Next(1, 29));
            Sex sex = (Sex)rand.Next(2);
            employees.Add(new Employee(name, date, sex));
        }
        return employees;
    }
    
    internal static IEnumerable<IEmployee> CreateEmployeeDto(List<Employee> employees)
    {
        IEnumerable<IEmployee> coll = from Employee employee in employees select
                                      new EmployeeDto(employee.Name, employee.BirthDay, (int)employee.Sex);
        return coll;
    }

    #region Private
    private static readonly string[] _name1 = ["Andreev", "Grigoryev", "Ivanov", "Petrov", "Dmitriev", "Bogdanov", "Vladimirov", "Nikolaev"];
    private static readonly string[] _name2 = ["Andrey", "Grigoriy", "Ivan", "Petr", "Dmitriy", "Bogdan", "Vladimir", "Nikolay"];
    private static readonly string[] _name3 = ["Andreevich", "Grigoryevich", "Ivanovich", "Petrovich", "Dmitrievich", "Bogdanovich", "Vladimirovich", "Nikolayevich"];

    private static string GetName(string str)
    {
        string name = str.Trim();
        if (!Employee.IsValidName(name))
        {
            throw new ArgumentException("Имя сотрудника не соответсвует формату");
        }
        return name;
    }

    private static DateOnly GetDate(string str)
    {
        if (!DateOnly.TryParse(str.Trim(), out DateOnly date))
        {
            throw new ArgumentException("Дата рождения сотрудника не соответсвует формату");
        }
        if (!Employee.IsValidAge(date))
        {
            throw new ArgumentException("Возраст сотрудника указан не верно");
        }
        return date;
    }

    private static Sex GetSex(string str)
    {
        return str.Trim().ToLower() switch
        {
            "male" => Sex.Male,
            "female" => Sex.Female,
            _ => throw new ArgumentException("Пол сотрудника не соответсвует формату"),
        };
    }
    #endregion
}
