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

        //TEntity Get(TPrimaryKey key);

        void Insert(TEntity entity);

        //void Update(TEntity entity);

        //void Delete(TPrimaryKey id);
    }

    public interface IRepository
    {

    }

}
