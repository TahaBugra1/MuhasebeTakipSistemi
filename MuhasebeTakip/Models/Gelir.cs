using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeTakip.Models
{
    public class Gelir : Islem
    {
        public override string IslemTuru => "Gelir";

        public override decimal NetEtki => Tutar; // Gelir pozitif etki

        public override string FormattedTutar => $"+{Tutar:N2} ₺";

        public override string GetDetayBilgi()
        {
            return $"GELİR: {base.GetDetayBilgi()}";
        }
    }
}
