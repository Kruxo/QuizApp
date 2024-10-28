namespace QuizApp;
public class Writer
{
    public ConsoleColor ErrorColor { get; init; } = ConsoleColor.Red;
    public ConsoleColor WarningColor { get; init; } = ConsoleColor.Yellow;
    public ConsoleColor InfoColor { get; init; } = ConsoleColor.White;
    public ConsoleColor SuccessColor { get; init; } = ConsoleColor.Green;

    public void ErrorLine(string message = "")
    {
        Console.ForegroundColor = ErrorColor;
        Console.WriteLine(message);
    }

    public void Error(string message = "")
    {
        Console.ForegroundColor = ErrorColor;
        Console.Write(message);
    }

    public void WarningLine(string message = "")
    {
        Console.ForegroundColor = WarningColor;
        Console.WriteLine(message);
    }

    public void Warning(string message = "")
    {
        Console.ForegroundColor = WarningColor;
        Console.Write(message);
    }

    public void InfoLine(string message = "")
    {
        Console.ForegroundColor = InfoColor;
        Console.WriteLine(message);
    }

    public void Info(string message = "")
    {
        Console.ForegroundColor = InfoColor;
        Console.Write(message);
    }

    public void SuccesLine(string message = "")
    {
        Console.ForegroundColor = SuccessColor;
        Console.WriteLine(message);
    }

    public void Success(string message = "")
    {
        Console.ForegroundColor = SuccessColor;
        Console.Write(message);
    }
}