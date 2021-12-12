using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        T GetById(int id);

        bool Insert(T entity);
        void InsertList(List<T> entities);

        void Update(T entity);
        void UpdateList(List<T> entities);

        void Delete(T entity);
        void DeleteList(List<T> entities);
    }
}
