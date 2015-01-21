using System;
using System.Collections.Generic;
using Exercise2.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Exercise2.Infrastructure
{
    public class SessionFactoryProvider : ISessionFactoryProvider
    {
        public NHibernate.ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(c => c.FromConnectionStringWithKey("Exercise2ConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>().)
                //.ExposeConfiguration(CreateSchema)
                .BuildSessionFactory();
        }

        private void CreateSchema(Configuration configuration)
        {
            var schemaExport = new SchemaExport(configuration);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
        }
    }
}
