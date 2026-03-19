using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
  public interface IExpenseRepository
  {
    public Expense? GetById(int id);
    public List<Expense> GetAll();
    public void Add(Expense expense);
    public void Save(List<Expense> expenses);
    public void Delete(int id);
  }
}