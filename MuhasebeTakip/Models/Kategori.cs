using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MuhasebeTakip.Models
{

    // Kalıtım değil Kompozisyon yapıyoruz
    public class Kategori
    {
        public string Ad { get; private set; }
        public string Aciklama { get; private set; }

        public Kategori(string ad, string aciklama = "")
        {
            if (string.IsNullOrWhiteSpace(ad))
                throw new ArgumentException("Kategori adı boş olamaz!");

            Ad = ad;
            Aciklama = aciklama;
        }

        public override string ToString()
        {
            return Ad;
        }
    }

}
