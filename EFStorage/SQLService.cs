using Abstract;
using EFStorage.Model;
using Microsoft.EntityFrameworkCore;

namespace EFStorage;
public class SQLService(string connectionString) : IDataStorage
{
    private readonly Model.StorageContext _storageContext = new(connectionString);

    public void CreateBD()
    {
        _storageContext.Database.EnsureCreated();
    }

    public IEnumerable<IEmployee> GetFilteredEmployees(string name, int sex)
    {
        IQueryable<IEmployee> coll = from employee in _storageContext.Employees
                   where EF.Functions.Like(employee.Name, name + "%") && employee.Sex == sex
                   select (IEmployee)employee;
        return coll;
    }

    public IEnumerable<IEmployee> GetUniqueEmployees()
    {
        IQueryable<Employee> coll = (from employee in _storageContext.Employees
                   orderby employee.Name
                   select employee);

        return coll.AsEnumerable().Distinct(new EmployeeComparer());
    }

    public void Save(IEnumerable<IEmployee> employees)
    {
        IEnumerable<Employee> list = from IEmployee item in employees select
                                     new Employee(item.Name, item.BirthDay, item.Sex);
        _storageContext.Employees.AddRange(list);
        _storageContext.SaveChanges();
    }

    public void SetIndex()
    {
        string sql = @"CREATE INDEX index_Name ON Employees (Name) INCLUDE (Sex)";
        _storageContext.Database.ExecuteSqlRaw(sql);
    }
}
