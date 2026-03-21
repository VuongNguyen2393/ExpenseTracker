using System.Windows.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Commands.Handler
{
  public class UpdateCommandHandler(IExpenseService expenseService) : ICommandHandler
  {
    private readonly IExpenseService _expenseService = expenseService;

    public void Handler(Command command)
    {
      throw new NotImplementedException();
    }
  }
}