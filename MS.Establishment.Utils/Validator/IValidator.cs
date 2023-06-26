using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Utils.Validator
{
    public interface IValidator

    {
        bool IsCnpj(string cnpj);
    }
}
