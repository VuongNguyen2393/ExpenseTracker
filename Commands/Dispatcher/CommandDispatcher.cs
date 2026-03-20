using ExpenseTracker.Commands.Handler;
using ExpenseTracker.Models;

namespace ExpenseTracker.Commands.Dispatcher
{
  public class CommandDispatcher(Dictionary<string, ICommandHandler> commandHandlerDict)
  {
    private readonly Dictionary<string, ICommandHandler> _commandHandlerDict = commandHandlerDict;
    public ICommandHandler? Dispatch(Command command)
    {
      if (!_commandHandlerDict.TryGetValue(command.CommandName, out ICommandHandler? value))
      {
        return null;
      }
      return value;
    }
  }
}