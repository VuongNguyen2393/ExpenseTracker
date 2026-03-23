using ExpenseTracker.Models;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services
{
  internal class ExpenseService(IExpenseRepository expenseRepository) : IExpenseService
  {
    private readonly IExpenseRepository _expenseRepository = expenseRepository;
    public void Add(string description, int amount)
    {
      var newExpense = new Expense
      {
        Id = CreateExpenseId(),
        Description = description,
        Amount = amount
      };
      _expenseRepository.Add(newExpense);
    }

    public void Delete(int id)
    {
      _expenseRepository.Delete(id);
    }

    public List<Expense> List()
    {
      return _expenseRepository.GetAll();
    }

    public int Summary()
    {
      var expenses = _expenseRepository.GetAll();
      return expenses.Sum(e => e.Amount);
    }

    public int SummaryByMonth(int month)
    {
      var expenses = _expenseRepository.GetAll();
      var expenseInMonth = expenses.Where(e => e.CreatedDatetime.Year == DateTime.Now.Year && e.CreatedDatetime.Month == month);
      return expenseInMonth.Sum(e => e.Amount);
    }

    public void Update(int id, string? description, int? amount)
    {
      var expenses = _expenseRepository.GetAll();
      var targetExpense = expenses.FirstOrDefault(e => e.Id == id);
      if (targetExpense == null)
      {
        System.Console.WriteLine("Expense Not Found");
        return;
      }
      targetExpense.Description = description ?? targetExpense.Description;
      targetExpense.Amount = amount ?? targetExpense.Amount;
      _expenseRepository.Save(expenses);
    }

    private int CreateExpenseId()
    {
      var expenses = _expenseRepository.GetAll();
      if (expenses.Count == 0)
      {
        return 1;
      }
      return expenses.Max(e => e.Id) + 1;
    }
  }
}