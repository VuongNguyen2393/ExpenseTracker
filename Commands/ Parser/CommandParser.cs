using ExpenseTracker.Models;

namespace ExpenseTracker.Commands.Parser
{
  public static class CommandParser
  {
    public static Command Parse(string input)
    {
      var parts = input.Split(" ", 2);
      var commandName = parts[0];
      var commandArgs = parts.Length > 1 ? parts[1].Split(" ") : Array.Empty<string>();
      return new Command
      {
        CommandName = commandName,
        CommandArgs = commandArgs
      };
    }
  }
}