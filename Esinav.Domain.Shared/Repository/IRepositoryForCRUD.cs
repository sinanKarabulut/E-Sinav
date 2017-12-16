using Esinav.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Shared.Repository
{
    public interface IRepositoryForCRUD<T> where T:class
    {
        T GetById(object id);

        T GetById(object[] id);

        IQueryable<T> Table { get; }

        OperationResult Insert(T entity);

        OperationResult Insert(IList<T> entityList);

        Task<OperationResult> InsertAsync(T entity);

        Task<OperationResult> InsertAsync(IList<T> entityList);

        OperationResult Update(T entity);

        OperationResult Update(IList<T> entityList);

        Task<OperationResult> UpdateAsync(T entity);

        Task<OperationResult> UpdateAsync(IList<T> entityList);

        OperationResult Delete(T entity);

        OperationResult Delete(IList<T> entityList);

        Task<OperationResult> DeleteAsync(T entity);

        Task<OperationResult> DeleteAsync(IList<T> entityList);

        IEnumerable<T_Target> ToList<T_Target>(IQueryable<T_Target> query);

        T_Target ToSingle<T_Target>(IQueryable<T_Target> query);
    }
}
