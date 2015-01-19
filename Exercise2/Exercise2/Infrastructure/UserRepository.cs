using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise2.Entities;

namespace Exercise2.Infrastructure
{
    public class UserRepository : RepositoryBase<User, int>
    {
        public UserRepository(ISessionFactoryProvider sessionFactoryProvider = null ) : base(sessionFactoryProvider)
        {
        }
    }
}
