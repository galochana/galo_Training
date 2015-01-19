using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise2.Entities;
using FluentNHibernate.Mapping;

namespace Exercise2.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ImageUrl);
            Map(x => x.UserType).CustomType<int>();
        }
    }
}
