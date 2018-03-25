using QueryRouter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRouter
{
    public interface IRoute
    {
        List<T> ResultSet<T>(DbType Type, Query Q);
    }
}
