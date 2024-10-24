namespace PTMK_Task.Model;
internal class Parameters
{
    public Parameters(WorkingMode workingMode)
    {
        WorkingMode = workingMode;
    }

    public Parameters(WorkingMode workingMode, string[] args)
    {
        WorkingMode = workingMode;
        Args = args;
    }

    internal WorkingMode WorkingMode { get; }
    internal string[]? Args { get; }
}
