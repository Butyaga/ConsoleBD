using PTMK_Task.Model;

namespace PTMK_Task.BL;
internal abstract class ExecutorBase(Parameters parameter)
{
    protected Parameters _parameter = parameter;

    internal virtual void Execute()
    {
        Console.WriteLine($"Программа запущена в режиме работы: {_parameter.WorkingMode}");
    }

    protected static void Success()
    {
        Console.WriteLine("Успешное завершение операции.");
    }

    protected static void Failure(Exception exception)
    {
        Console.WriteLine("Что-то пошло не так");
        Console.WriteLine(exception.Message);
    }

    protected static void PrintEmployees(List<Employee> list)
    {
        if (list.Count > 0)
        {
            Console.WriteLine("Список сотрудников:");
            foreach (Employee employee in list)
            {
                Console.WriteLine($"{employee.Name}, b/d {employee.BirthDay}, {employee.Sex}, age {employee.Age}");
            }
        }
        else
        {
            Console.WriteLine("Список сотрудников пуст");
        }
    }
}
