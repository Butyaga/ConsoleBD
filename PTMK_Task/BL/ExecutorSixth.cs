using PTMK_Task.DAL;
using PTMK_Task.Model;

namespace PTMK_Task.BL;
internal class ExecutorSixth(Parameters parameter) : ExecutorBase(parameter)
{
    internal override void Execute()
    {
        base.Execute();

        try
        {
            DBService.GetInstance.SetIndex();
            Success();
        }
        catch (Exception exception)
        {
            Failure(exception);
        }
    }
}
