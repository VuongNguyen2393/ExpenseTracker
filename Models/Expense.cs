namespace ExpenseTracker.Models
{
  public class Expense
  {
    public int Id { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public required string Description { get; set; }
    public int Amount { get; set; }
  }
}