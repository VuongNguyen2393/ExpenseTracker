using System;
using System.Reflection.Metadata;
using ExpenseTracker.Commands.Dispatcher;
using ExpenseTracker.Commands.Handler;
using ExpenseTracker.Commands.Parser;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;

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
            // {"view" , new ViewCommandHandler(expenseService)},
            // {"view" , new AddCommandHandler(expenseService)}
        };
        var commandDispatcher = new CommandDispatcher(commandDict);
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                System.Console.WriteLine("Invalid input");
                return;
            }
            var command = CommandParser.Parse(input);
            var commandHandler = commandDispatcher.Dispatch(command);
            if (commandHandler == null)
            {
                System.Console.WriteLine("Unsupported Command");
                return;
            }
            commandHandler.Handler(command);
        }
    }
}
