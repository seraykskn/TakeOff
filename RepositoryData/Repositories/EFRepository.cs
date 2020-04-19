using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RepositoryData;


namespace RepositoryData.Repositories
{
    public class EFRepository<T>: IRepository<T> where T:class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(ContextClass dbContext)
        {
            //if (dbContext == null)
            //{
            //    throw new ArgumentNullException("dbcontext can not be null.");


            //}

            this._dbContext=dbContext;
            this._dbSet=dbContext.Set<T>();


        }

         #region IRepository Members
         public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        //public virtual T Add(T entity)
        // {
        //     _dbContext.Set<T>().Add(entity);
        //     return entity;
        // }
 
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            var query = _dbSet.Where(predicate);
            return query;   
        }
        public T FindByID(object id)
        {
            return _dbSet.Find(id);
        }
 
       
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
            
        }
        public void Save(T entity)
        {
            _dbContext.SaveChanges();
        }
 
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            
        }
 
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            
        }
 
        public void Delete(T entity)
        {
            // kayıtı silmek yerine IsDelete şeklinde bool alanı tutuyoruz
            // refleciton kodu bunu otomatik yapıyor.
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;
 
                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);
 
                this.Update(_entity);
            }
            else
            {
                
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
 
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
        }
 
        //public void Delete(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //    _dbContext.SaveChanges();
            
        //}
       
        #endregion
    }

    
}
