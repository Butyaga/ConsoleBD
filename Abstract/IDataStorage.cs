namespace Abstract;
public interface IDataStorage
{
    public void CreateBD();
    public void Save(IEnumerable<IEmployee> employees);
    public IEnumerable<IEmployee> GetUniqueEmployees();
    public IEnumerable<IEmployee> GetFilteredEmployees(string name, int sex);
    public void SetIndex();
}
