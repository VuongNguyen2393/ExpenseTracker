# Expense Tracker

A simple console-based expense tracking application built with C# and .NET. This application allows you to manage your personal expenses through a command-line interface, storing data in a JSON file.<br> Project Idea: https://roadmap.sh/projects/expense-tracker

## Features

- **Add Expenses**: Record new expenses with description and amount.
- **List Expenses**: View all recorded expenses in a tabular format.
- **Update Expenses**: Modify existing expenses by ID.
- **Delete Expenses**: Remove expenses by ID.
- **Summary**: Get total expenses or expenses for a specific month.
- **Persistent Storage**: All data is stored in a JSON file for persistence.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 10.0 or later)

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/VuongNguyen2393/ExpenseTracker.git
   cd ExpenseTracker
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

## Usage

Run the application:

```bash
dotnet run
```

The application will start an interactive console. Enter commands at the prompt (`>`).

### Commands

#### Add an Expense

```
add --description "Lunch at restaurant" --amount 25
```

Adds a new expense with the specified description and amount.

#### List All Expenses

```
list
```

Displays all expenses in a table format showing ID, Date, Amount, and Description.

#### Update an Expense

```
update --id 1 --description "Updated description" --amount 30
```

Updates the expense with ID 1. You can update description, amount, or both.

#### Delete an Expense

```
delete --id 1
```

Deletes the expense with the specified ID.

#### View Summary

```
summary
```

Shows the total amount of all expenses.

```
summary --month 3
```

Shows the total expenses for March (replace 3 with the desired month number).

#### Exit

```
Ctrl+C
```

Exits the application.

## Project Structure

```
ExpenseTracker/
├── Commands/
│   ├── Dispatcher/
│   │   └── CommandDispatcher.cs
│   ├── Handler/
│   │   ├── AddCommandHandler.cs
│   │   ├── DeleteCommandHandler.cs
│   │   ├── ICommandHandler.cs
│   │   ├── ListCommandHandler.cs
│   │   ├── SummaryCommandHandler.cs
│   │   └── UpdateCommandHandler.cs
│   └── Parser/
│       └── CommandParser.cs
├── Data/
│   └── ExpenseStorage.json
├── Models/
│   ├── Command.cs
│   └── Expense.cs
├── Repositories/
│   ├── IExpenseRepository.cs
│   └── JsonExpenseRepository.cs
├── Services/
│   ├── ExpenseService.cs
│   └── IExpenseService.cs
├── Utils/
│   └── ConsoleHelper.cs
├── Program.cs
├── ExpenseTracker.csproj
└── ExpenseTracker.sln
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.</content>
<parameter name="filePath">/Users/vuongnguyen/Desktop/Personal Project/DotNet Projects/ExpenseTracker/README.md
