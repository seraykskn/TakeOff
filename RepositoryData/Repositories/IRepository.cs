using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryData.Repositories
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        
        T Get(Expression<Func<T, bool>> predicate);

        T FindByID(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save(T entity);
    }
}
