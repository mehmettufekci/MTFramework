using MTFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int RoleId { get; set; }
        public virtual int UserId { get; set; }
    }
}

