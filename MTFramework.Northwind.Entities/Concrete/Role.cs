using MTFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Entities.Concrete
{
    public class Role : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
