using MTFramework.Northwind.Entities.ComplexTime;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string userName, string password);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
