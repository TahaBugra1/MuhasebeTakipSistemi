# 📊 Muhasebe Takip Sistemi

Bu proje, kişisel veya küçük işletmelerin finansal işlemlerini (gelir/gider) kolaylıkla takip edebilmesini sağlayan basit ve anlaşılır bir masaüstü uygulamasıdır.

## 🎯 Proje Amacı

- Gelir ve giderlerin kayıt altına alınması
- Finansal verilerin kategorilere ayrılması
- Aylık olarak toplam gelir, gider ve net bakiyenin hesaplanması
- (Opsiyonel) Grafiksel raporlama ile görselleştirme

## 🛠️ Kullanılan Teknolojiler

- C# (WinForms)
- .NET Framework
- LINQ
- Chart Bileşeni (opsiyonel grafikler için)

## 🧩 Temel Özellikler

- 🔹 Gelir ve Gider Ekleme
- 🔹 Kategorisel Filtreleme (örn. Yemek, Fatura, Maaş)
- 🔹 Aylık Bilanço Hesaplama
- 🔹 Basit Arayüz ile kullanım kolaylığı
- 🔹 (İsteğe bağlı) Grafiksel Raporlama

## 🧱 OOP Yapısı

- `Islem` (Abstract): Tutar, Tarih, Kategori
- `Gelir` ve `Gider`: `Islem` sınıfından türetilmiştir
- `Kategori`: Harcamaların ya da gelirlerin ait olduğu gruplar
- 
