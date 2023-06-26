using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.Helpers
{
    public static class ConvertToListHelper
    {
        public static bool Try(object obj)
        {
            try
            {
                _ = (IList)obj;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Any(object obj)
        {
            return ((IList)obj).Count > 0;
        }
    }
}
