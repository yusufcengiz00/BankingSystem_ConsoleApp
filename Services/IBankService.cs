namespace Service;
using Models;

public interface IBankService
{
//KULLANICI İŞLEMLERİ    
User CreateUser(int id, string name);

//HESAP İŞLEMLERİ
void OpenAccount(User user, string accountNumber, decimal balance);

void Deposit(BankAccount account , decimal amount);

void WithDraw(BankAccount account , decimal amount);

//TRANSFER
void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount);

// KREDİ KARTI İŞLEMLERİ
void IssueCreditCard(User user, string cardNumber,decimal limit);
void MakeCreditCardPayment(CreditCard card, BankAccount fromAccount, decimal amount);
}
