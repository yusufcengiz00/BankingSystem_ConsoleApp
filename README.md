# 🏦 Banking System Console Application

C# ve Nesne Yönelimli Programlama (OOP) prensipleri kullanılarak geliştirilmiş, kapsamlı bir bankacılık simülasyonu konsol uygulamasıdır. Bu proje, bir bankanın temel operasyonlarını (hesap yönetimi, para transferleri, kredi kartı işlemleri) servis katmanı mimarisiyle simüle eder.

## 🚀 Özellikler

- **Kullanıcı Yönetimi:** Benzersiz ID'ler ile kullanıcı oluşturma ve yönetme.
- **Hesap Operasyonları:** - Mevduat hesabı açma (TL/Bakiye takibi).
  - Para yatırma ve çekme işlemleri.
  - Hesaplar arası güvenli transfer (Havale/EFT).
- **Kredi Kartı Sistemi:**
  - Limit tanımlama ve kullanılabilir limit takibi.
  - Harcama yapma ve hesaptan borç ödeme entegrasyonu.
- **İşlem Geçmişi (Transactions):** Her hesap için yapılan tüm finansal hareketlerin (Tarih, Tip, Tutar) loglanması.
- **Hata Yönetimi:** Bakiye yetersizliği, null referanslar ve hatalı hesap numaraları için özel kontrol mekanizmaları.

## 🏗️ Teknik Mimari

Proje, sürdürülebilir ve test edilebilir bir yapı için **Interface tabanlı Servis Katmanı** mimarisini kullanır:

- **Models:** Veri yapılarını temsil eder (`User`, `BankAccount`, `CreditCard`, `Transaction`).
- **Services:** İş mantığının (Business Logic) yürütüldüğü katmandır. `IBankService` arayüzü ile soyutlanmıştır.
- **OOP Prensipleri:** Encapsulation, Inheritance ve Abstraction aktif olarak kullanılmıştır.

## 💻 Kurulum ve Çalıştırma

Projenin bilgisayarınızda çalışması için .NET SDK'nın yüklü olması gerekmektedir.

1. Repoyu klonlayın:
   ```bash
   git clone [https://github.com/yusufcengiz00/BankingSystem_ConsoleApp.git](https://github.com/yusufcengiz00/BankingSystem_ConsoleApp.git)
   
2. Proje dizinine gidin:
    ```bash
    cd BankingSystem_ConsoleApp

4. Uygulamayı Çalıştırın:
   ```bash
    dotnet run

## 📊 Örnek Çıktı
Plaintext

=== BANKA SİSTEMİ MERKEZİ ===

[SİSTEM]: Kullanıcılar oluşturuldu: Yusuf Cengiz ve Ahmet Yılmaz

[HESAP]: TR123456 nolu hesap (Yusuf Cengiz) - Bakiye: 18000 TL
...

--- Transfer İşlemi Yapılıyor ---

[KULLANICI]: Yusuf Cengiz
> Banka Bakiyesi    : 6000 TL

> Kredi Kartı Borcu : 10000 TL

## 🛠️ Kullanılan Teknolojiler
- Dil: C# (.NET 10.0)
- Versiyon Kontrol: Git & GitHub
- Modelleme: UML (PlantUML)

<img width="1462" height="733" alt="Ekran görüntüsü 2026-04-24 150146" src="https://github.com/user-attachments/assets/b956e93a-70a9-46b5-b7be-44d02d3caf90" />
