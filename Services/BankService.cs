using Models;

namespace Service;

public class BankService : IBankService
{

    private readonly List<User> users = new List<User>();
    

    public User CreateUser(int id, string name)
    {
        var newUser = new User(id, name); //Yeni Kullanıcı Oluşturma
        users.Add(newUser); // Sisteme kaydetme

        return newUser;
    }

    public void Deposit(BankAccount account, decimal amount)
    {
        if(account == null) throw new ArgumentNullException(nameof(account));
        // Modelin içindeki kendi mantığını çağırıyorum
        account.Deposit(amount);
    }

    public void IssueCreditCard(User user, string cardNumber, decimal limit)
    {
        if(user==null) throw new ArgumentNullException(nameof(user));
        //Yeni kredi kartı tanımlama
        var creditCard = new CreditCard(cardNumber,limit, 0);
        user.AddCreditcard(creditCard);
    }

    public void MakeCreditCardPayment(CreditCard card, BankAccount fromAccount, decimal amount)
    {
        if(card == null) throw new ArgumentNullException(nameof(card));
        if(fromAccount == null) throw new ArgumentNullException(nameof(fromAccount));
        
        // Kredi kartı kendi borç ödeme mantığını (PayDebt) çalıştırır, 
    // o da banka hesabının çekim (WithDraw) mantığını tetikler.
    card.PayDebt(amount, fromAccount);
    
    Console.WriteLine("Ödeme işlemi servis aracılığıyla tamamlandı.");

    }

    public void OpenAccount(User user, string accountNumber, decimal balance)
    {
        if(user==null) throw new ArgumentNullException(nameof(user));

        //Yeni hesap oluşturma
        var newAccount = new BankAccount(accountNumber, balance);

        user.AddAccount(newAccount);
    }

    public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        if(fromAccount==null) throw new ArgumentNullException(nameof(fromAccount));
        if(toAccount==null) throw new ArgumentNullException(nameof(toAccount));
        if(fromAccount.AccountNumber == toAccount.AccountNumber) throw new Exception("Gönderen Hesap ile Alıcı Hesap aynı olamaz!");
        fromAccount.WithDraw(amount);
        toAccount.Deposit(amount);
    }

    public void WithDraw(BankAccount account, decimal amount)
    {
        if(account == null) throw new ArgumentNullException(nameof(account));

        account.WithDraw(amount);
    }
}