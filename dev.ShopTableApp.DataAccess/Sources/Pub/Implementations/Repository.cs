using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using dev.ShopTableApp.DataAccess.EF.Pub;
using dev.ShopTableApp.DataAccess.Pub.Contracts;

namespace dev.ShopTableApp.DataAccess.Pub.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private ShopTableAppDbContext _dataContext;
        private readonly IDbSet<T> _dbset;
        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
        }

        protected ShopTableAppDbContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            DataContext.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Deleted;
            DataContext.SaveChanges();
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }


    }
}
