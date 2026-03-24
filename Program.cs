using System;
using System.Reflection.Metadata;
using ExpenseTracker.Commands.Dispatcher;
using ExpenseTracker.Commands.Handler;
using ExpenseTracker.Commands.Parser;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;
using ExpenseTracker.Utils;

namespace ExpenseTracker;

class Program
{
    private const string FILE_PATH = "./Data/ExpenseStorage.json";
    static void Main(string[] args)
    {
        var jsonRepository = new JsonExpenseRepository(FILE_PATH);
        var expenseService = new ExpenseService(jsonRepository);
        var commandDict = new Dictionary<string, ICommandHandler>()
        {
            {"add" , new AddCommandHandler(expenseService)},
            {"delete" , new DeleteCommandHandler(expenseService)},
            {"summary" , new SummaryCommandHandler(expenseService)},
            {"update" , new UpdateCommandHandler(expenseService)},
            {"list" , new ListCommandHandler(expenseService)}
        };
        var commandDispatcher = new CommandDispatcher(commandDict);
        ConsoleHelper.PrintProjectName();
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                ConsoleHelper.PrintError("Invalid input");
                continue;
            }
            var command = CommandParser.Parse(input);
            var commandHandler = commandDispatcher.Dispatch(command);

            if (commandHandler == null)
            {
                ConsoleHelper.PrintWarning("Unsupported Command");
                continue;
            }

            commandHandler.Handler(command);
        }
    }
}
