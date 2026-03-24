using System.ComponentModel.Design;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;
using Microsoft.VisualBasic;

namespace ExpenseTracker.Commands.Handler
{
  public class AddCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    const string descriptionSign = "--description";
    const string amountSign = "--amount";

    private readonly IExpenseService _expenseService = expenseService;

    public void Handler(Command command)
    {
      var descriptionIdx = command.CommandArgs.IndexOf(descriptionSign);
      var amountIdx = command.CommandArgs.IndexOf(amountSign);

      if (!IsValidatedAddCommandArgs(command, descriptionIdx, amountIdx))
      {
        ConsoleHelper.PrintError("Invalid Command.\nPlease use the syntax:\nadd --description [description] --amount [amount]");
        return;
      }

      var description = ExtractDescriptionValue(command, descriptionIdx, amountIdx);

      if (!int.TryParse(command.CommandArgs[amountIdx + 1], out var ammount))
      {
        ConsoleHelper.PrintError("Invalid amount");
        return;
      }

      _expenseService.Add(description, ammount);
      ConsoleHelper.PrintInfo("Add new expense successfully");
    }

    private bool IsValidatedAddCommandArgs(Command command, int descriptionIdx, int amountIdx)
    {
      if (command.CommandArgs.Count() < 4 ||
          descriptionIdx < 0 || descriptionIdx == command.CommandArgs.Count() - 1 ||
          amountIdx < 0 || amountIdx == command.CommandArgs.Count() - 1)
      {
        return false;
      }
      return true;
    }

    private static string ExtractDescriptionValue(Command command, int descriptionIdx, int amountIdx)
    {
      IEnumerable<string> descriptionParts;
      if (descriptionIdx > amountIdx)
      {
        descriptionParts = command.CommandArgs.Skip(3);
      }
      else
      {
        descriptionParts = command.CommandArgs.Skip(descriptionIdx + 1).Take(amountIdx - descriptionIdx - 1);
      }
      return string.Join(" ", descriptionParts).Trim('"');
    }
  }
}