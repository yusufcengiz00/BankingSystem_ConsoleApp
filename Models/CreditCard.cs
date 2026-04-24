namespace Models;

public class CreditCard
{

    public string CardNumber{get;}
    public decimal Limit { get; private set;}

    public decimal CurrentDebt { get; private set;}

    private readonly List<Transaction> _transactions = new List<Transaction>();
    public IEnumerable<Transaction> Transactions => _transactions;

    public CreditCard(string cardNumber, decimal limit, decimal currentDebt)
    {
        CardNumber = cardNumber;
        Limit = limit;
        CurrentDebt = 0;
    }

    public void Spend(decimal amount)
    {
        if(amount <= 0) throw new Exception("Çekilecek Tutar Pozitif olmalı!");
        // Kullanılabilir limit kontrolü: (Limit - Borç)
        if (amount > GetAvailableLimit()) 
            throw new InvalidOperationException("Yetersiz limit!");
        CurrentDebt += amount;
        _transactions.Add(new Transaction(_transactions.Count + 1 , "Sped", amount, DateTime.Now));
    }

    public void PayDebt(decimal amount, BankAccount fromAccount)
    {
        if(amount<=0) throw new ArgumentException("Ödenecek borç tutarı 0' dan büyük olmak zorundadır.");
        if(amount>CurrentDebt) throw new InvalidOperationException("Borcunuzdan fazla tutarda ödeme yapamazsınız!");

        fromAccount.WithDraw(amount);
        CurrentDebt -= amount;
        _transactions.Add(new Transaction(_transactions.Count + 1, "PayDebt", amount, DateTime.Now));
    }

    public decimal GetAvailableLimit()
    {
        return Limit-CurrentDebt;
    }

}
