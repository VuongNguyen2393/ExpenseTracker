namespace ExpenseTracker.Models
{
  public class Expense(string description, int amount)
  {
    public int Id { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public required string Description { get; set; } = description;
    public int Amount { get; set; } = amount;
  }
}