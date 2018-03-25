using QueryRouter.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRouter
{
    internal interface IResult
    {
        List<T> GetResult<T>(IDbConnection Connection,Query Q);
    }
}
