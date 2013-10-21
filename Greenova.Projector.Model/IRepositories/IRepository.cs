using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greenova.Projector.Model.IRepositories
{
    public interface IRepository<T>
    {
        T FindBy(int id);

        IEnumerable<T> FindAll();

        void Save(T entity);
    }
}
