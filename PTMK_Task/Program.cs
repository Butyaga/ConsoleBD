using EFStorage;
using PTMK_Task.BL;
using PTMK_Task.DAL;
using PTMK_Task.Model;

namespace PTMK_Task;
internal class Program
{
    private static readonly Dictionary<WorkingMode, Type> _startWorkingMode = [];
    private static void Main(string[] args)
    {
        Parameters? parameters = ArgsParser.Parse(args);
        if (parameters == null)
        {
            return;
        }

        Init();
        bool success = _startWorkingMode.TryGetValue(parameters.WorkingMode, out Type? type);
        if (!success)
        {
            return;
        }

        if (type != null)
        {
            ExecutorBase? executor = Activator.CreateInstance(type, parameters) as ExecutorBase;
            executor?.Execute();
        }
    }

    private static void Init()
    {
        DBService.SetService(new SQLService("Server=.;Database=EmplTest;Trusted_Connection=True;Encrypt=False"));

        _startWorkingMode.Add(WorkingMode.First, typeof(ExecutorFirst));
        _startWorkingMode.Add(WorkingMode.Second, typeof(ExecutorSecond));
        _startWorkingMode.Add(WorkingMode.Third, typeof(ExecutorThird));
        _startWorkingMode.Add(WorkingMode.Fourth, typeof(ExecutorFourth));
        _startWorkingMode.Add(WorkingMode.Fifth, typeof(ExecutorFifth));
        _startWorkingMode.Add(WorkingMode.Sixth, typeof(ExecutorSixth));
    }
}