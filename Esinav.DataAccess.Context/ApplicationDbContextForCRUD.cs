using Esinav.DataAccess.Location;
using Esinav.Domain.Identity.Entity;
using Esinav.Domain.Shared.DbContext;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.DataAccess.Context
{
    public class ApplicationDbContextForCRUD : IdentityDbContext<ApplicationUser>, IDbContextForCRUD
    {
        public ApplicationDbContextForCRUD()
           : base("EsinavDataConnection", throwIfV1Schema: false)
        {

        }

        public ApplicationDbContextForCRUD(string connectionName, bool throwIfV1Schema)
           : base(connectionName, throwIfV1Schema)
        {

        }

        public static ApplicationDbContextForCRUD CreateApplicationDbContextForCRUD()
        {
            return new ApplicationDbContextForCRUD();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schemeName = ConfigurationManager.
                AppSettings["Esinav.DataAccess.DefaultScheme"];


            modelBuilder.HasDefaultSchema(schemeName);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            // IDENTITY

            modelBuilder.Entity<ApplicationUser>().ToTable("IDUser", schemeName);
            modelBuilder.Entity<IdentityUserRole>().ToTable("IDUserRole", schemeName);
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IDUserLogin", schemeName);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IDUserClaim", schemeName);
            modelBuilder.Entity<IdentityRole>().ToTable("IDRole", schemeName);

            // LOCATION
            modelBuilder.Configurations.Add(new MapSehir());
            modelBuilder.Configurations.Add(new MapIlce());

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
