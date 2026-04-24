using System.Transactions;

namespace Models;

public class BankAccount
{   
    public string AccountNumber { get; internal set; }
    public decimal Balance { get; private set; }    
    private readonly List<Transaction> _transactions = new List<Transaction>();
    public IEnumerable<Transaction> Transactions => _transactions;

    public BankAccount(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if(amount <= 0) throw new ArgumentException("Yatırılıcak tutar 0'dan büyük olmalı.");
        Balance += amount;
        _transactions.Add(new Transaction(1, "Deposit", amount, DateTime.Now));
    }

    public void WithDraw(decimal amount)
    {
        if(amount<=0) throw new ArgumentException("Çekilecek Tutar 0' dan büyük olmalı.");
        if(amount>Balance) throw new InvalidOperationException("Yetersiz Bakiye!");

        Balance-=amount;
        _transactions.Add(new Transaction(2, "WithDraw", amount, DateTime.Now));
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}
