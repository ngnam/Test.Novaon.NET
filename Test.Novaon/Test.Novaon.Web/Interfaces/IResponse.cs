using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Novaon.Web.Interfaces
{
    public interface IResponse
    {
        IResult<object> Result { get; set; }
        bool HasError { get; set; }
        List<IdentityError> Errors { get; set; }
    }
}
