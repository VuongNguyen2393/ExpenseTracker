using System.Runtime.CompilerServices;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
  public interface IExpenseService
  {
    public void Add(string description, int amount);
    public void Update(int id, string? description, int? amount);
    public void Delete(int id);
    public List<Expense> List();
    public int Summary();
    public int SummaryByMonth(int month);
  }
}