using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Novaon.Web.Interfaces;

namespace Test.Novaon.Web.Entities
{
    public class BaseEntity<Tkey> : IEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
