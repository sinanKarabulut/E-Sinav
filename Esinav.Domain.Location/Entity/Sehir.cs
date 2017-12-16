using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Esinav.Domain.Location.Entity
{
    [Serializable]
    public class Sehir
    {
        public int Sehir_Id { get; set; }

        public String Sehir_Adi { get; set; }

        [XmlIgnore]
        public virtual ICollection<Ilce>  Ilces { get; set; }
    }
}
