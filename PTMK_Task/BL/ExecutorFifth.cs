using PTMK_Task.DAL;
using PTMK_Task.Model;
using System.Diagnostics;

namespace PTMK_Task.BL;
internal class ExecutorFifth(Parameters parameter) : ExecutorBase(parameter)
{
    internal override void Execute()
    {
        base.Execute();

        try
        {
            string startWith = "F";
            Sex sex = Sex.Male;
            Stopwatch sw = Stopwatch.StartNew();
            List<Employee> employees = DBService.GetInstance.GetFilteredEmployees(startWith, sex);
            sw.Stop();
            PrintEmployees(employees);
            Console.WriteLine($"Продолжительность выборки - {sw.ElapsedMilliseconds} миллисекунд");
            Success();
        }
        catch (Exception exception)
        {
            Failure(exception);
        }
    }
}
