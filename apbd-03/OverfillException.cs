namespace apbd_03;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.Error.WriteLine("Uwaga nastąpiło przepełnienie!");
    }
}