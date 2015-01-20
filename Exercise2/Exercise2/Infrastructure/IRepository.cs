using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise2.Entities;

namespace Exercise2.Infrastructure
{
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        List<TEntity> GetAll();

        void Insert(TEntity entity);
    }

    public interface IRepository
    {

    }

}
