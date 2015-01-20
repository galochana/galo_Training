using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise2.Entities;
using NHibernate;
using NHibernate.Impl;
using NHibernate.Linq;

namespace Exercise2.Infrastructure
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        private readonly ISessionFactory _sessionFactory;

        protected RepositoryBase(ISessionFactoryProvider sessionFactoryProvider = null)
        {
            _sessionFactory = sessionFactoryProvider == null
                ? new SessionFactoryProvider().GetSessionFactory()
                : sessionFactoryProvider.GetSessionFactory();
        }

        public List<TEntity> GetAll()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(entity);
            }
        }

    }
}
