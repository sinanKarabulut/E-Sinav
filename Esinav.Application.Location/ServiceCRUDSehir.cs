using Esinav.Domain.Location.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esinav.Domain.Location.Entity;
using Esinav.Domain.Shared.ValueObject;
using Esinav.Domain.Shared.Repository;

namespace Esinav.Application.Location
{
    public class ServiceCRUDSehir : IServiceCRUDSehir
    {
        private readonly IRepositoryForCRUD<Sehir> _sehirRepository;

        public ServiceCRUDSehir(IRepositoryForCRUD<Sehir> sehirRepository)
        {
            this._sehirRepository = sehirRepository;
        }

        public Sehir CreateNew()
        {
            return new Sehir();
        }

        public OperationResult Delete(Sehir entity)
        {
            throw new NotImplementedException();
        }

        public Sehir GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Sehir> GetByIdQuery(int id)
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

        public OperationResult Insert(Sehir entity)
        {
            OperationResult result = this._sehirRepository.Insert(entity);

            return result;
        }

        public OperationResult Update(Sehir entity)
        {
            throw new NotImplementedException();
        }
    }
}
