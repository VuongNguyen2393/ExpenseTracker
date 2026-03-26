namespace ExpenseTracker.Utils
{
  public static class Validator
  {
    public static void ValidateDescription(string description)
    {
      if (string.IsNullOrEmpty(description))
      {
        ConsoleHelper.PrintError("Invalid description");
      }
    }

    public static bool TryParseAmount(string amountStr, out int amountOutput, out string errorMessage)
    {
      amountOutput = 0;
      if (!int.TryParse(amountStr, out var amount))
      {
        errorMessage = "Amount is numeric";
        return false;
      }

      if (amount <= 0)
      {
        errorMessage = "Amount is positive number";
      }
      amountOutput = amount;
      errorMessage = string.Empty;
      return true;
    }

    public static bool TryParseId(string idStr, out int idInt, out string errorMessage)
    {
      idInt = 0;
      if (!int.TryParse(idStr, out var id))
      {
        errorMessage = "Id is numeric";
        return false;
      }

      if (id <= 0)
      {
        errorMessage = "Id is positive number";
        return false;
      }
      idInt = id;
      errorMessage = string.Empty;
      return true;
    }
  }
}