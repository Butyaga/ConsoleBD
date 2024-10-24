using PTMK_Task.DAL;
using PTMK_Task.Model;

namespace PTMK_Task.BL;
internal class ExecutorFourth(Parameters parameter) : ExecutorBase(parameter)
{
    internal override void Execute()
    {
        base.Execute();

        try
        {
            List<Employee> employees = ModelFactory.GetRamdomEmployees(1000000);
            DBService.GetInstance.Save(employees);

            employees.Clear();
            for (int i = 0; i < 100; i++)
            {
                employees.Add(new Employee("Fedotov Oleg Ivanovich", new DateOnly(1978, 4, 26), Sex.Male));
            }
            DBService.GetInstance.Save(employees);
            
            Success();
        }
        catch (Exception exception)
        {
            Failure(exception);
        }
    }
}

