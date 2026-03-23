using System.Windows.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
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
        System.Console.WriteLine("Invalid command.");
        return;
      }

      if (!int.TryParse(command.CommandArgs[idIdx + 1], out var id))
      {
        System.Console.WriteLine("Invalid id");
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
          System.Console.WriteLine("Invalid amount");
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
    }
  }
}