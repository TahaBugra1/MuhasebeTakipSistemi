using MuhasebeTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeTakip.Managers
{
    public class KategoriYoneticisi
    {
        private List<Kategori> _kategoriler;

        public KategoriYoneticisi()
        {
            _kategoriler = new List<Kategori>
            {
                new Kategori("Maaş", "Aylık maaş geliri"),
                new Kategori("Satış", "Satış geliri"),
                new Kategori("Yatırım", "Yatırım geliri"),
                new Kategori("Kira", "Kira gideri"),
                new Kategori("Market", "Market alışverişi"),
                new Kategori("Yakıt", "Yakıt gideri"),
                new Kategori("Fatura", "Fatura ödemeleri"),
                new Kategori("Eğlence", "Eğlence giderleri"),
                new Kategori("Sağlık", "Sağlık giderleri"),
                new Kategori("Diğer", "Diğer giderler")
            };
        }

        public List<Kategori> TumKategorileriGetir()
        {
            return _kategoriler.ToList();
        }

        public Kategori KategoriBul(string ad)
        {
            return _kategoriler.FirstOrDefault(k => k.Ad == ad);
        }
    }
}
