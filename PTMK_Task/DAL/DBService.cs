using Abstract;
using PTMK_Task.Model;

namespace PTMK_Task.DAL;
internal class DBService(IDataStorage dataStorage)
{
    private readonly IDataStorage _dataStorage = dataStorage;
    private static DBService? _service;

    internal static DBService GetInstance => _service ?? throw new Exception("Используйте метод SetService для инициации");
    
    internal static void SetService(IDataStorage dataStorage)
    {
        _service = new DBService(dataStorage);
    }

    internal void CreateDB()
    {
        _dataStorage.CreateBD();
    }

    internal void Save(Employee employee)
    {
        List<Employee> list = [employee];
        IEnumerable<IEmployee> dto = ModelFactory.CreateEmployeeDto(list);
        _dataStorage.Save(dto);
    }

    internal void Save(List<Employee> employees)
    {
        IEnumerable<IEmployee> listDto = ModelFactory.CreateEmployeeDto(employees);
        _dataStorage.Save(listDto);
    }

    internal List<Employee> GetUniqueEmployees()
    {
        IEnumerable<IEmployee> dto = _dataStorage.GetUniqueEmployees();
        return ModelFactory.CreateEmployee(dto);
    }

    internal List<Employee> GetFilteredEmployees(string name, Sex sex)
    {
        IEnumerable<IEmployee> dto = _dataStorage.GetFilteredEmployees(name, (int)sex);
        return ModelFactory.CreateEmployee(dto);
    }

    internal void SetIndex() { _dataStorage.SetIndex(); }
}
