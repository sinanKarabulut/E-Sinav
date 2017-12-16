using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Shared.DbContext
{
    public interface IDbContextForCRUD
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        Database Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
