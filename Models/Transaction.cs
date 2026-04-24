namespace Models;

public class Transaction
{

    public int Id { get; }
    public string Type { get; } //"Deposit" veya "Withdraw"
    public decimal Amount { get; }
    public DateTime Date{get;}

    public Transaction(int id, string type, decimal amount, DateTime date)
    {
        Id = id;
        Type = type;
        Amount = amount;
        Date = date;
    }  
}