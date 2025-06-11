using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeTakip.Models
{
    public abstract class Islem
    {
        private int _id;
        private DateTime _tarih;
        private string _aciklama;
        private decimal _tutar;
        private Kategori _kategori; // Kompozisyon

        // Kapsülleme - Property'ler ile veri kontrolü
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID sıfırdan büyük olmalıdır!");
                _id = value;
            }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Tarih gelecek bir zaman olamaz!");
                _tarih = value;
            }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Açıklama boş olamaz!");
                _aciklama = value.Trim();
            }
        }

        public decimal Tutar
        {
            get { return _tutar; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Tutar sıfırdan büyük olmalıdır!");
                _tutar = value;
            }
        }

        public Kategori Kategori
        {
            get { return _kategori; }
            set
            {
                _kategori = value;
            }
        }

        // Soyut metotlar - Alt sınıflarda implementasyon zorunlu yani override edilmeli.
        public abstract string IslemTuru { get; }
        public abstract decimal NetEtki { get; }
        public abstract string FormattedTutar { get; }

        // Ortak metot. Bu kısmı da override edebiliriz.
        public virtual string GetDetayBilgi()
        {
            return $"{Tarih:dd/MM/yyyy} - {Aciklama} - {FormattedTutar} ({Kategori.Ad})";
        }
    }
}
