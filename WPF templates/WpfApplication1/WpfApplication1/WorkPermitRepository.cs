using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;

namespace WpfApplication1
{
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        Task<TEntity> Get(TKey id);
        Task Save(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> FindAll();
    }

    public interface IWorkPermitRepository : IRepository<WorkPermit, Guid>
    {
    }

    internal class WorkPermitRepository : IWorkPermitRepository
    {
        private readonly LiteDatabase _dbContext;
        private readonly LiteCollection<WorkPermit> _permitsCollection;

        public WorkPermitRepository()
        {
            _dbContext = new LiteDatabase("workpermit.db");
            _permitsCollection = _dbContext.GetCollection<WorkPermit>("permits");
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public Task<WorkPermit> Get(Guid id)
        {
            return Task.Run(() => _permitsCollection.FindById(id));
        }

        public Task Save(WorkPermit entity)
        {
            return Task.Run(
                () =>
                {
                    if (_permitsCollection.FindById(entity.Id) != null)
                    {
                        _permitsCollection.Update(entity.Id, entity);
                    }
                    else
                    {
                        _permitsCollection.Insert(entity.Id, entity);
                    }
                }
                );
        }

        public Task Delete(WorkPermit entity)
        {
            return Task.Run(() => _permitsCollection.Delete(entity.Id));
        }

        public Task<IEnumerable<WorkPermit>> FindAll()
        {
            return Task.Run(() => _permitsCollection.FindAll());
        }
    }
}