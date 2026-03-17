namespace ExpenseTracker.Models
{
  public class Command
  {
    public required string CommandName { get; set; }
    public required string[] CommandArgs { get; set; }
  }
}