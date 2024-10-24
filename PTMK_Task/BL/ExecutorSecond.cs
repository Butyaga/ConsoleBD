using PTMK_Task.DAL;
using PTMK_Task.Model;

namespace PTMK_Task.BL;
internal class ExecutorSecond(Parameters parameter) : ExecutorBase(parameter)
{
    internal override void Execute()
    {
        base.Execute();

        try
        {
            Employee employee = ModelFactory.CreateEmployee(_parameter.Args);
            employee.SaveDB();
            Success();
        }
        catch (Exception exception)
        {
            Failure(exception);
        }
    }
}
