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
        File.WriteAllText(filePath, string.Empty);
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
      if (string.IsNullOrEmpty(expensesStr))
      {
        return new List<Expense>();
      }
      var expenses = JsonSerializer.Deserialize<List<Expense>>(expensesStr);
      return expenses ?? new List<Expense>();
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