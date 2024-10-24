using PTMK_Task.DAL;
using PTMK_Task.Model;
using System;
using System.Collections.Generic;
namespace PTMK_Task.BL;

internal class ExecutorThird(Parameters parameter) : ExecutorBase(parameter)
{
    internal override void Execute()
    {
        base.Execute();

        try
        {
            List<Employee> employees = DBService.GetInstance.GetUniqueEmployees();
            PrintEmployees(employees);
            Success();
        }
        catch (Exception exception)
        {
            Failure(exception);
        }
    }
}
