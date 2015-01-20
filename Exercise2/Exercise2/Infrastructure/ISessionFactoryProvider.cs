using System.Collections.Generic;
using System.Data;
using NHibernate;

namespace Exercise2.Infrastructure
{
    public interface ISessionFactoryProvider
    {
        ISessionFactory GetSessionFactory();
    }
}
