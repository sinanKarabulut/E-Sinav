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
    public class MapIlce : EntityTypeConfiguration<Ilce>
    {
        public MapIlce()
        {
            HasKey(c => c.Ilce_Id);

            Property(c => c.Ilce_Id)
                .HasColumnName("Ilce_Id")
                .HasColumnOrder(10)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Sehir_Id)
                .HasColumnName("Sehir_Id")
                .HasColumnOrder(20)
                .IsRequired();

            Property(c => c.Ilce_Adi)
                .HasColumnName("Ilce_Adi")
                .HasColumnOrder(30)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");


            //Relations
            HasRequired(c => c.Sehir)
                .WithMany(co => co.Ilces)
                .HasForeignKey(c => c.Sehir_Id)
                .WillCascadeOnDelete(true);

            string schemeName = ConfigurationManager.
               AppSettings["Esinav.DataAccess.DefaultScheme"];

            ToTable("Ilce", schemeName);
        }
    }
}
