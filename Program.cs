using Models;
using Service;
using System;
using System.Linq;

// Servis başlatma
IBankService bankService = new BankService();

try
{
    Console.WriteLine("=== BANKA SİSTEMİ MERKEZİ ===\n");

    // 1. Kullanıcıların Oluşturulması
    User user = bankService.CreateUser(1, "Yusuf Cengiz");
    User user2 = bankService.CreateUser(2, "Ahmet Yılmaz");
    
    Console.WriteLine($"[SİSTEM]: Kullanıcılar oluşturuldu: {user.Name} ve {user2.Name}");

    // 2. Hesapların Açılması
    bankService.OpenAccount(user, "TR123456", 18000m);
    bankService.OpenAccount(user2, "TR789101", 0m);

    // Yusuf'un ana hesabını ve Ahmet'in hesabını değişkenlere alalım
    var yusufAccount = user.Accounts.First();
    var ahmetAccount = user2.Accounts.First();

    Console.WriteLine($"[HESAP]: {yusufAccount.AccountNumber} nolu hesap ({user.Name}) - Bakiye: {yusufAccount.Balance} TL");
    Console.WriteLine($"[HESAP]: {ahmetAccount.AccountNumber} nolu hesap ({user2.Name}) - Bakiye: {ahmetAccount.Balance} TL");

    // 3. Kredi Kartı Tanımlama (Önce tanımla, sonra çek!)
    bankService.IssueCreditCard(user, "5872 5465 21 213", 50000m);
    var myCard = user.CreditCards.First(); // Artık liste dolu olduğu için hata vermez
    
    Console.WriteLine($"[KART]: Kredi kartı {user.Name} adına tanımlandı: {myCard.CardNumber}");

    // 4. Bankacılık İşlemleri (Para Yatırma / Çekme)
    Console.WriteLine("\n--- Mevduat İşlemleri Yapılıyor ---");
    bankService.Deposit(yusufAccount, 1000m);  // Bakiye: 19.000
    bankService.WithDraw(yusufAccount, 500m);   // Bakiye: 18.500

    // 5. Kredi Kartı Harcaması ve Ödemesi
    Console.WriteLine("\n--- Kredi Kartı İşlemleri Yapılıyor ---");
    myCard.Spend(20000m); // Borç: 20.000 | Limit: 30.000
    Console.WriteLine($"[HARCAMA]: 20.000 TL harcandı. Güncel Borç: {myCard.CurrentDebt} TL");
    
    bankService.MakeCreditCardPayment(myCard, yusufAccount, 10000m); // Borç 10.000'e düşer, hesaptan 10.000 çıkar
    Console.WriteLine($"[ÖDEME]: 10.000 TL kart borcu ödendi.");

    // 6. Transfer İşlemi (Yusuf -> Ahmet)
    Console.WriteLine("\n--- Transfer İşlemi Yapılıyor ---");
    bankService.Transfer(yusufAccount, ahmetAccount, 2500m); // Yusuf'tan 2.500 çıkar, Ahmet'e eklenir

    // === SONUÇ EKRANI ===
    Console.WriteLine("\n" + new string('=', 30));
    Console.WriteLine("          FİNAL RAPORU          ");
    Console.WriteLine(new string('=', 30));

    // Yusuf'un Hesap Durumu
    Console.WriteLine($"\n[KULLANICI]: {user.Name}");
    Console.WriteLine($"> Banka Bakiyesi    : {yusufAccount.GetBalance()} TL");
    Console.WriteLine($"> Kredi Kartı Borcu : {myCard.CurrentDebt} TL");
    Console.WriteLine($"> Kullanılabilir Lim: {myCard.GetAvailableLimit()} TL");

    // İşlem Geçmişi (Yusuf)
    Console.WriteLine("\n[HESAP HAREKETLERİ]:");
    foreach (var item in yusufAccount.Transactions)
    {
        Console.WriteLine($" - {item.Date:HH:mm:ss} | {item.Type,-12} | {item.Amount,8} TL");
    }

    // Ahmet'in Durumu
    Console.WriteLine($"\n[KULLANICI]: {user2.Name}");
    Console.WriteLine($"> Banka Bakiyesi    : {ahmetAccount.GetBalance()} TL");

    Console.WriteLine("\n" + new string('=', 30));
    Console.WriteLine("İşlemler başarıyla tamamlandı.");
}
catch (Exception ex)
{
    Console.WriteLine($"\n!!! KRİTİK HATA !!!\nMesaj: {ex.Message}");
}

Console.WriteLine("\nÇıkmak için bir tuşa basın...");
Console.ReadKey();