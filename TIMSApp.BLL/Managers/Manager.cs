using System;
using System.Collections.Generic;
using System.Text;
using TIMSApp.BLL.Contracts;
using TIMSApp.Repositories.Contracts;

namespace TIMSApp.BLL.Managers
{
   public class Manager<T>:IManager<T> where T:class 
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual bool Add(T entity)
        {
          return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
