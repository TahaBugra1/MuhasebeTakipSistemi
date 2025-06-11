# Muhasebe Takip Sistemi

Bu proje, kişisel veya küçük işletme muhasebe işlemlerini takip etmek için geliştirilmiş bir Windows Forms uygulamasıdır. Nesne yönelimli programlama (OOP) prensipleri kullanılarak C# ile geliştirilmiştir.

## Özellikler

### 📊 Temel Fonksiyonlar
- *Gelir/Gider Takibi*: Farklı kategorilerde gelir ve gider işlemleri ekleme
- *İşlem Yönetimi*: Mevcut işlemleri görüntüleme ve silme
- *Kategori Bazlı Organizasyon*: İşlemleri kategorilere ayırarak düzenli takip
- *Gerçek Zamanlı Hesaplama*: Toplam gelir, gider ve net kar/zarar hesaplama

### 📈 Görselleştirme
- *Pasta Grafiği*: Kategorilere göre harcama dağılımının görsel sunumu
- *Detaylı Analiz*: Her kategorinin tutar ve yüzde bilgileri
- *Renk Kodlu Gösterim*: Her kategori için farklı renk paleti

### 💼 Kullanıcı Arayüzü
- *Modern Tasarım*: Kullanıcı dostu ve temiz arayüz
- *Data Grid Görünümü*: Tüm işlemlerin tablo formatında listelenmesi
- *Özet Paneli*: Hızlı finansal durum görünümü
- *Form Validasyonu*: Hatalı veri girişlerini önleme

- ![WhatsApp Görsel 2025-06-11 saat 18 49 26_74658a9d](https://github.com/user-attachments/assets/9b041885-57f2-4337-9e9f-1a9eabe6a2fd)


## Teknik Özellikler

### 🏗 Mimari
- *Nesne Yönelimli Tasarım*: Kapsülleme, kalıtım ve polimorfizm kullanımı
- *Separation of Concerns*: İş mantığı ve UI ayrımı
- *Manager Pattern*: İşlem ve kategori yöneticisi sınıfları

### 🛠 Teknolojiler
- *Framework*: .NET Framework / .NET Core
- *UI*: Windows Forms
- *Grafik*: System.Windows.Forms.DataVisualization.Charting
- *Dil*: C#

## Kurulum

### Gereksinimler
- Visual Studio 2019 veya üzeri
- .NET Framework 4.7.2 veya üzeri / .NET Core 3.1 veya üzeri
- Windows işletim sistemi

### Adımlar
1. Projeyi bilgisayarınıza klonlayın veya indirin
2. Visual Studio ile MuhasebeTakip.sln dosyasını açın
3. Projeyi derleyin (Build → Build Solution)
4. Uygulamayı çalıştırın (F5)

## Kullanım Kılavuzu

### Yeni İşlem Ekleme
1. *Açıklama* alanına işlem açıklamasını girin
2. *Tutar* alanına tutarı girin (pozitif sayı)
3. *Tür* dropdown'ından "Gelir" veya "Gider" seçin
4. *Kategori* dropdown'ından uygun kategoriyi seçin
5. *İşlem Ekle* butonuna tıklayın

### İşlem Silme
1. İşlem listesinden silinecek işlemi seçin
2. *Seçili Sil* butonuna tıklayın
3. Onay mesajında "Evet"i seçin

### Grafik Analizi
- Pasta grafiği otomatik olarak kategorilere göre güncellenecektir
- Grafiğin altındaki listede detaylı analiz bilgilerini görebilirsiniz
- Her kategori için tutar ve yüzde bilgileri görüntülenir

## Proje Yapısı


```
MuhasebeTakip/
├── Models/
│   ├── Islem.cs              # Temel işlem sınıfı
│   ├── Gelir.cs              # Gelir işlemi sınıfı
│   ├── Gider.cs              # Gider işlemi sınıfı
│   └── Kategori.cs           # Kategori sınıfı
├── Managers/
│   ├── IslemYoneticisi.cs    # İşlem yönetimi
│   └── KategoriYoneticisi.cs # Kategori yönetimi
├── Forms/
│   ├── AnaForm.cs            # Ana form
│   └── Form1.cs              # Form1
└── Program.cs                # Uygulama giriş noktası
```


## OOP Prensipleri

### Kapsülleme (Encapsulation)
- Tüm sınıflarda private alanlar ve public property'ler kullanımı
- Veri güvenliği ve kontrollü erişim

### Kalıtım (Inheritance)
- Gelir ve Gider sınıfları Islem sınıfından türetilmiştir
- Ortak özelliklerin yeniden kullanımı

### Polimorfizm (Polymorphism)
- Islem türündeki nesneler çalışma zamanında türlerine göre davranır
- Sanal metodlar ve geçersiz kılma (override) kullanımı

### Soyutlama (Abstraction)
- Manager sınıfları ile iş mantığının gizlenmesi
- Clean code prensipleri

## Genişletme İmkanları

### Özellik Eklemeleri
- *Tarih Filtreleme*: Belirli tarih aralıklarında raporlama
- *Dışa Aktarma*: Excel/PDF formatında rapor oluşturma
- *Veritabanı Entegrasyonu*: Verilerin kalıcı saklanması
- *Kullanıcı Yönetimi*: Multi-user desteği
- *Backup/Restore*: Veri yedekleme ve geri yükleme

### Grafik Geliştirmeleri
- *Çizgi Grafiği*: Zaman bazlı trend analizi
- *Bar Grafiği*: Karşılaştırmalı görünüm
- *Dashboard*: Çoklu grafik görünümü

## Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (git checkout -b feature/YeniOzellik)
3. Değişikliklerinizi commit edin (git commit -am 'Yeni özellik eklendi')
4. Branch'inizi push edin (git push origin feature/YeniOzellik)
5. Pull Request oluşturun

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir ve açık kaynak kodludur.

## Geliştiriciler

- Taha Buğra AK
- Mustafa ÇEKCEOĞLU
