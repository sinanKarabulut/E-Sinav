using Esinav.Domain.Identity.Entity;
using Esinav.Domain.Identity.Service;
using Esinav.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esinav.Domain.Shared.ValueObject;

namespace Esinav.Application.Identity
{
    public class ServiceCRUDUser : IServiceCRUDUser
    {
        private readonly IRepositoryForCRUD<ApplicationUser> _userRepository;

        public ServiceCRUDUser(
           IRepositoryForCRUD<ApplicationUser> userRepository
       )
        {
            this._userRepository = userRepository;
        }

        public ApplicationUser CreateNew()
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetByIdQuery(string id)
        {
            throw new NotImplementedException();
        }

        public TTargetType GetByIdWithProjection<TTargetType>(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery)
        {
            throw new NotImplementedException();
        }

        public OperationResult Insert(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
