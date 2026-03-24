namespace ExpenseTracker.Utils
{
  public static class ConsoleHelper
  {
    public static void PrintProjectName()
    {
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      System.Console.WriteLine(new string('=', 35));
      System.Console.WriteLine("=   EXPENSE TRACKER CLI PROJECT   =");
      System.Console.WriteLine(new string('=', 35));
      Console.ResetColor();
    }

    public static void PrintHeader(string text)
    {
      PrintColor(text.ToUpper(), ConsoleColor.Cyan);
    }

    public static void PrintRow(string text)
    {
      PrintColor(text, ConsoleColor.DarkGray);
    }


    public static void PrintInfo(string text)
    {
      PrintColor($"{text}\n", ConsoleColor.Green);
    }

    public static void PrintWarning(string text)
    {
      PrintColor($"{text}\n", ConsoleColor.DarkYellow);
    }

    public static void PrintError(string text)
    {
      PrintColor($"{text}\n", ConsoleColor.Red);
    }

    private static void PrintColor(string text, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      System.Console.WriteLine(text);
      Console.ResetColor();
    }
  }
}