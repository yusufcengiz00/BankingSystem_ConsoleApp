using System;
using System.Collections.Generic;
using System.Linq;

namespace Models;

public class User
{
    public int Id { get; }
    public string Name { get; }

    // Private listelerin ismini '_' ile başlatmak standarttır
    private readonly List<BankAccount> _accounts = new List<BankAccount>();
    private readonly List<CreditCard> _creditCards = new List<CreditCard>();

    // Dışarıya açılan kapılar
    public IEnumerable<BankAccount> Accounts => _accounts;
    public IEnumerable<CreditCard> CreditCards => _creditCards;

    public User(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("İsim boş olamaz.");
        Id = id;
        Name = name;
    }

    public void AddAccount(BankAccount account)
    {
        if (account == null) throw new ArgumentNullException(nameof(account));
        
        if (_accounts.Any(a => a.AccountNumber == account.AccountNumber))
            throw new InvalidOperationException("Aynı hesap numarasına sahip bir hesap zaten mevcut!");

        _accounts.Add(account);
    }

    public void AddCreditcard(CreditCard creditCard)
    {
        if (creditCard == null) throw new ArgumentNullException(nameof(creditCard));

        // Noktalı virgül hatasını düzelttik ve süslü parantez ekledik
        if (_creditCards.Any(c => c.CardNumber == creditCard.CardNumber))
        {
            throw new InvalidOperationException("Bu kredi kartı zaten tanımlı!");
        }

        _creditCards.Add(creditCard);
    }
}