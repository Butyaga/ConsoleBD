using Abstract;

namespace PTMK_Task.DAL;
public record class EmployeeDto(string Name, DateOnly BirthDay, int Sex) : IEmployee { }
