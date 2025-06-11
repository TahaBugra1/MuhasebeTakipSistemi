using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeTakip.Models
{
    public class Gider : Islem
    {
        public override string IslemTuru => "Gider";

        public override decimal NetEtki => -Tutar; // Gider negatif etki

        public override string FormattedTutar => $"-{Tutar:N2} ₺";

        public override string GetDetayBilgi()
        {
            return $"GİDER: {base.GetDetayBilgi()}";
        }
    }
}
