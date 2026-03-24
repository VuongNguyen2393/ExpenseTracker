using System.Windows.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;
using Microsoft.VisualBasic;

namespace ExpenseTracker.Commands.Handler
{
  public class UpdateCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;

    public void Handler(Command command)
    {
      var idIdx = command.CommandArgs.IndexOf("--id");
      var descriptionIdx = command.CommandArgs.IndexOf("--description");
      var amountIdx = command.CommandArgs.IndexOf("--amount");
      if (idIdx < 0 ||
          (descriptionIdx < 0 && amountIdx < 0) ||
          idIdx == command.CommandArgs.Length - 1 ||
          descriptionIdx == command.CommandArgs.Length - 1 ||
          amountIdx == command.CommandArgs.Length - 1)
      {
        ConsoleHelper.PrintError("Invalid command.\nPlease use syntax:\n update --id [id] --description [description] --amount [amount]");
        return;
      }

      if (!int.TryParse(command.CommandArgs[idIdx + 1], out var id))
      {
        ConsoleHelper.PrintError("Invalid id");
        return;
      }


      int? amount;
      if (amountIdx < 0)
      {
        amount = null;
      }
      else
      {
        if (!int.TryParse(command.CommandArgs[amountIdx + 1], out int amountTemp))
        {
          ConsoleHelper.PrintError("Invalid amount");
          return;
        }
        amount = amountTemp;
      }

      string? description = null;
      if (descriptionIdx >= 0)
      {
        var commandArgStr = string.Join(" ", command.CommandArgs);
        var containedDescription = commandArgStr.Split("--description", 2)[1];
        var descriptionFiltedId = containedDescription.Split("--id", 2)[0];
        description = descriptionFiltedId.Split("--amount", 2)[0].Trim();
      }


      _expenseService.Update(id, description, amount);
      ConsoleHelper.PrintInfo("Update successfully");
    }
  }
}