using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Novaon.Web.Interfaces
{
    public interface IResult<TData>
    {
        TData data { get; set; }
        IPaging paging { get; set; }
    }
}
