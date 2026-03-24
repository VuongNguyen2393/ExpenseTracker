using System.ComponentModel.Design;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;
using Microsoft.VisualBasic;

namespace ExpenseTracker.Commands.Handler
{
  public class DeleteCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;
    public void Handler(Command command)
    {
      if (command.CommandArgs.Count() != 2 || command.CommandArgs.IndexOf("--id") != 0)
      {
        ConsoleHelper.PrintError("Invalid Command.\nPlease use the syntax:\ndelete --id [id]");
        return;
      }

      if (!int.TryParse(command.CommandArgs[1], out var id))
      {
        ConsoleHelper.PrintError("ID should be a number");
        return;
      }

      _expenseService.Delete(id);
      ConsoleHelper.PrintInfo("Delete Successfully");
    }
  }
}