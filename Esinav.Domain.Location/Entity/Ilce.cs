using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Esinav.Domain.Location.Entity
{
    [Serializable]
    public class Ilce
    {
        public int Ilce_Id { get; set; }

        public int Sehir_Id { get; set; }
        public String Ilce_Adi { get; set; }

        [XmlIgnore]
        public virtual Sehir Sehir { get; set; }

    }
}
