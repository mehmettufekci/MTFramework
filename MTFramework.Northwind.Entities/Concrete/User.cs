using MTFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Entities.Concrete
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Email { get; set; }
    }
}
