using PTMK_Task.Model;

namespace PTMK_Task;
internal static class ArgsParser
{
    internal static Parameters? Parse(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("При запуске не было передано ни одного параметра.");
            Sample();
            return null;
        }

        WorkingMode workingMode = ParseWorkingMode(args[0]);
        if (workingMode == WorkingMode.None)
        {
            Console.WriteLine("При запуске был передан неправильный режим работы.");
            Sample();
            return null;
        }
        else if (workingMode == WorkingMode.Second)
        {
            if (args.Length > 1)
            {
                return new Parameters(workingMode, args[1..]);
            }
            Console.WriteLine("При запуске во втором режиме также требуется передать данные.");
            Sample();
            return null;
        }
        return new Parameters(workingMode);
    }

    private static WorkingMode ParseWorkingMode(string arg)
    {
        bool success = int.TryParse(arg, out int intArg);
        if (!success)
        {
            return WorkingMode.None;
        }

        int maxEnumValue = Enum.GetValues(typeof(WorkingMode)).Cast<int>().Max();
        if ((intArg < 1) || (intArg > maxEnumValue))
        {
            return WorkingMode.None;
        }

        return (WorkingMode)intArg;
    }

    private static void Sample()
    {
        string programName = AppDomain.CurrentDomain.FriendlyName;
        Console.WriteLine("Примеры запуска программы с параметрами:");
        Console.WriteLine($"{programName} 1");
        Console.WriteLine($"{programName} 2 \"Ivanov Petr Sergeevich\" 2009-07-12 Male");
        Console.WriteLine($"{programName} 3");
        Console.WriteLine($"{programName} 4");
        Console.WriteLine($"{programName} 5");
        Console.WriteLine($"{programName} 6");
    }
}
