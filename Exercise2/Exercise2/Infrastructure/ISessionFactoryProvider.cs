using System.Collections.Generic;
using System.Data;
using NHibernate;

namespace Exercise2.Infrastructure
{
    public interface ISessionFactoryProvider
    {
        ISession GetSession<T>();
        IStatelessSession GetStatelessSession<T>();
        IDbConnection GetConnection<T>();
        IEnumerable<ISessionFactory> GetFactories();
        ISessionFactory GetSessionFactory();
    }
}
