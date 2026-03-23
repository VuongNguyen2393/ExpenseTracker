using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Commands.Handler
{
  public class ListCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;
    public void Handler(Command command)
    {
      if (command.CommandArgs.Length != 0)
      {
        System.Console.WriteLine("Invalid command");
        return;
      }
      var expenses = _expenseService.List();
      System.Console.WriteLine($"{"ID",-4} {"Date",-10} {"Amount",-10} {"Description"}");
      foreach (var expense in expenses)
      {
        System.Console.WriteLine($"{expense.Id,-4} {expense.CreatedDatetime.ToString("yyyy-MM-dd"),-10} {expense.Amount,-10} {expense.Description}");
      }
    }
  }
}