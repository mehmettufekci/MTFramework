using MTFramework.Core.DataAccess.NHibernate;
using MTFramework.Northwind.DataAccess.Abstract;
using MTFramework.Northwind.Entities.ComplexTime;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhUserDal : NhEntityRepositoryBase<User>, IUserDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhUserDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from ur in session.Query<UserRole>()
                             join r in session.Query<Role>() on ur.RoleId equals r.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };

                return result.ToList();

            }
        }
    }
}
