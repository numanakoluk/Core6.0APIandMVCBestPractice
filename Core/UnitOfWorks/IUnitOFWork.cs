using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWorks
{
    public interface IUnitOFWork
    {
        //DbContext bir saveChanges bir de saveChangesAsyn methodu var 
        //Transactions'ta commit ismi daha çok kullanılır.
        Task CommitAsync();
        void Commit();
    }
}
