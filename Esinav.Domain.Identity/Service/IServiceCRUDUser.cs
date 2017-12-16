using Esinav.Domain.Identity.Entity;
using Esinav.Domain.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Identity.Service
{
    public interface IServiceCRUDUser : IServiceCRUD<string, ApplicationUser>
    {
    }
}
