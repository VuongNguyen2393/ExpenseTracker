using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;

namespace ExpenseTracker.Commands.Handler
{
  public class SummaryCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;
    public void Handler(Command command)
    {
      if (command.CommandArgs.Length == 0)
      {
        var summary = _expenseService.Summary();
        ConsoleHelper.PrintInfo($"Total expense: ${summary}");
      }
      else if (command.CommandArgs.Length == 2)
      {
        if (command.CommandArgs.IndexOf("--month") != 0)
        {
          ConsoleHelper.PrintError("Invalid Command.\nPlease use the syntax:\nsummary --month [month]");
          return;
        }

        if (!int.TryParse(command.CommandArgs[1], out var month))
        {
          ConsoleHelper.PrintError("Invalid month");
          return;
        }

        if (month < 1 || month > 12)
        {
          ConsoleHelper.PrintError("Invalid month");
          return;
        }
        var summary = _expenseService.SummaryByMonth(month);
        var monthName = new DateTime(2026, month, 1).ToString("MMMM");
        ConsoleHelper.PrintInfo($"Total expense for {monthName}: ${summary}");
      }
      else
      {
        ConsoleHelper.PrintError("Invalid Command.\nPlease use the syntax:\nsummary --month [month]");
      }
    }
  }
}