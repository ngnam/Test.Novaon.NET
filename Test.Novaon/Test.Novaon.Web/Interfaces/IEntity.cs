using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Novaon.Web.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
