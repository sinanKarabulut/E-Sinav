using Esinav.Domain.Location.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esinav.Domain.Location.Entity;
using Esinav.Domain.Shared.ValueObject;

namespace Esinav.Application.Location
{
    public class ServiceCRUDIlce : IServiceCRUDIlce
    {
        public Ilce CreateNew()
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(Ilce entity)
        {
            throw new NotImplementedException();
        }

        public Ilce GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ilce> GetByIdQuery(int id)
        {
            throw new NotImplementedException();
        }

        public TTargetType GetByIdWithProjection<TTargetType>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery)
        {
            throw new NotImplementedException();
        }

        public OperationResult Insert(Ilce entity)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(Ilce entity)
        {
            throw new NotImplementedException();
        }
    }
}
