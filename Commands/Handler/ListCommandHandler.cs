using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;

namespace ExpenseTracker.Commands.Handler
{
  public class ListCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;
    public void Handler(Command command)
    {
      if (command.CommandArgs.Length != 0)
      {
        ConsoleHelper.PrintError("Invalid list command.\n Please use the syntax:\nlist");
        return;
      }
      var expenses = _expenseService.List();
      ConsoleHelper.PrintHeader(new string('*', 50));
      ConsoleHelper.PrintHeader($"| {"ID",-4} | {"Date",-10} | {"Amount",-10} | {"Description"} ");
      ConsoleHelper.PrintHeader(new string('*', 50));

      foreach (var expense in expenses)
      {
        ConsoleHelper.PrintRow($"| {expense.Id,-4} | {expense.CreatedDatetime.ToString("yyyy-MM-dd"),-10} | {expense.Amount,-10} | {expense.Description} ");
      }
    }
  }
}