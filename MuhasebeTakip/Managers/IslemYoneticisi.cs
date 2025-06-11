using MuhasebeTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeTakip.Managers
{
    public class IslemYoneticisi
    {
        private List<Islem> _islemler;
        private int _sonrakiId;

        public IslemYoneticisi()
        {
            _islemler = new List<Islem>();
            _sonrakiId = 1;
        }

        public void IslemEkle(Islem islem)
        {
            if (islem == null)
                throw new ArgumentNullException("İşlem null olamaz!");

            islem.Id = _sonrakiId++;
            _islemler.Add(islem);
        }

        public bool IslemSil(int id)
        {
            var islem = _islemler.FirstOrDefault(i => i.Id == id);
            if (islem != null)
            {
                _islemler.Remove(islem);
                return true;
            }
            return false;
        }

        public List<Islem> TumIslemleriGetir()
        {
            return _islemler.OrderByDescending(i => i.Tarih).ToList();
        }

        public decimal ToplamGelir => _islemler.OfType<Gelir>().Sum(g => g.Tutar);

        public decimal ToplamGider => _islemler.OfType<Gider>().Sum(g => g.Tutar);

        public decimal NetKar => ToplamGelir - ToplamGider;

        public int ToplamIslemSayisi => _islemler.Count;

        public Dictionary<string, decimal> KategoriDagilimi()
        {
            return _islemler
                .GroupBy(i => i.Kategori.Ad)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.Tutar));
        }
    }
}
