using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication2.Models;
using LiteDB;

namespace WpfApplication2.Services
{
    public interface IWorkPermitRepository : IDisposable
    {
        WorkPermit Get(string id);
        void Save(WorkPermit entity);
        void Delete(Guid id);
        IEnumerable<WorkPermit> FindAll();
        IEnumerable<WorkPermit> Find(string text);
        new void Dispose();
    }

    public class WorkPermitRepository : IWorkPermitRepository
    {
        private readonly LiteDatabase _dbContext;
        LiteCollection<WorkPermit> _workPermits;

        public WorkPermitRepository()
        {
            _dbContext = new LiteDatabase("workpermitmanager.db");
            
            _workPermits = _dbContext.GetCollection<WorkPermit>("workpermits");
        }


        public WorkPermit Get(string id)
        {
            return null;
        }

        public void Save(WorkPermit entity)
        {
            if (_workPermits.FindById(entity.Id) == null)
            {
                _workPermits.Insert(entity);
            }
            else
            {
                _workPermits.Update(entity);
            }
        }

        public void Delete(Guid id)
        {
           _workPermits.Delete(id);
        }

        public IEnumerable<WorkPermit> FindAll()
        {
            return _workPermits.FindAll();
        }

        public IEnumerable<WorkPermit> Find(string text)
        {
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
