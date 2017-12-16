using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Identity.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Kullanici_Adi { get; set; }

        [MaxLength(100)]
        public string Kullanici_Soyadi { get; set; }

        [MaxLength(30)]
        public string Iban_No { get; set; }

        [MaxLength(200)]
        public String Adres { get; set; }


        public bool? Gender { get; set; }

        public int Kullanici_Tip_Id { get; set; }

        public DateTime Kayit_Zamani { get; set; }

        [MaxLength(50)]
        public string Kayit_Ip { get; set; }

        public DateTime Guncelleme_Zamani { get; set; }

        [MaxLength(50)]
        public string Guncelleme_Ip { get; set; }

        public string Tc_No { get; set; }

        [DefaultValue("true")]
        public bool Aktif { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}
