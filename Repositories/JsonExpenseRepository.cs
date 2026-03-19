using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
  public class JsonExpenseRepository : IExpenseRepository
  {
    private readonly string _filePath;
    public JsonExpenseRepository(string filePath)
    {
      if (!File.Exists(filePath))
      {
        File.Create(filePath);
      }
      _filePath = filePath;
    }
    public void Add(Expense expense)
    {
      var expenses = GetAll();
      expenses.Add(expense);
      Save(expenses);
    }

    public void Delete(int id)
    {
      var expenses = GetAll();
      var targetExpense = expenses.FirstOrDefault(e => e.Id == id);
      if (targetExpense != null)
      {
        expenses.Remove(targetExpense);
      }
    }

    public List<Expense> GetAll()
    {
      var expensesStr = File.ReadAllText(_filePath);
      var expenses = JsonSerializer.Deserialize<List<Expense>>(expensesStr);
      return expenses ?? [];
    }

    public Expense? GetById(int id)
    {
      var expenses = GetAll();
      return expenses.FirstOrDefault(e => e.Id == id);
    }

    public void Save(List<Expense> expenses)
    {
      var expenseStr = JsonSerializer.Serialize<List<Expense>>(expenses);
      File.WriteAllText(_filePath, expenseStr);
    }
  }
}