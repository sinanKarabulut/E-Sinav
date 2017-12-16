using Esinav.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Shared.Service
{
    public interface IServiceCRUD<TPrimaryIdType, TType>
    {
        TType CreateNew();

        OperationResult Insert(TType entity);

        TType GetById(TPrimaryIdType id);

        OperationResult Delete(TType entity);

        IQueryable<TType> GetByIdQuery(TPrimaryIdType id);

        TTargetType GetByIdWithProjection<TTargetType>(TPrimaryIdType id);


        IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery);

        OperationResult Update(TType entity);

    }
}
