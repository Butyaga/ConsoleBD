using System.Diagnostics.CodeAnalysis;

namespace EFStorage.Model;
public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        if (x == null || y == null) return false;
        if (x.Name == y.Name && x.BirthDay == y.BirthDay) return true;
        return false;
    }

    public int GetHashCode([DisallowNull] Employee employee)
    {
        return employee.Id;
    }
}
