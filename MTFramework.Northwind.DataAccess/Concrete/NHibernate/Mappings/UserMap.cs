using FluentNHibernate.Mapping;
using MTFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table(@"USERS");

            LazyLoad();

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("USERS_SEQ");

            Map(x => x.UserName).Column("USERNAME");
            Map(x => x.Password).Column("PASSWORD");
            Map(x => x.FirstName).Column("FIRSTNAME");
            Map(x => x.LastName).Column("LASTNAME");
            Map(x => x.Email).Column("EMAIL");

        }
    }
}