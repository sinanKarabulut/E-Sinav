using Esinav.Domain.Location.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.DataAccess.Location
{
    public class MapSehir : EntityTypeConfiguration<Sehir>
    {
        public MapSehir()
        {
            HasKey(c => c.Sehir_Id);

            Property(c => c.Sehir_Id)
                .HasColumnName("Sehir_Id")
                .IsRequired()
                .HasColumnOrder(10)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Sehir_Adi)
                .HasColumnName("Sehir_Adi")
                .HasColumnOrder(20)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            string schemeName = ConfigurationManager.
                AppSettings["Esinav.DataAccess.DefaultScheme"];

            ToTable("Sehir", schemeName);

        }
    }
}
