using ExpenseTracker.Models;

namespace ExpenseTracker.Commands.Handler
{
  public interface ICommandHandler
  {
    public void Handler(Command command);
  }
}