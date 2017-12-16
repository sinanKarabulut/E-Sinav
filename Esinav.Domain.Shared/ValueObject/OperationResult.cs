using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esinav.Domain.Shared.ValueObject
{
    public class OperationResult
    {

        public OperationResult(bool succeeded)
        {
            this.Succeeded = succeeded;
            this.Errors = new List<string>();
        }

        public IList<string> Errors { get; set; }

        public bool Succeeded { get; set; }

    }
}
