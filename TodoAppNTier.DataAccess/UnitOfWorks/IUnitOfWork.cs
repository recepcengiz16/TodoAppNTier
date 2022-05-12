using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepositories<T>() where T : BaseEntity ;

        Task SaveChanges();

    }
}
