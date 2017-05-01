using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;

namespace WpfApplication1
{
    public interface IAttachmentRepository : IRepository<Attachment, Guid>
    {
    }

    internal class AttachmentRepository : IAttachmentRepository
    {
        private readonly LiteDatabase _dbContext;
        private readonly LiteCollection<Attachment> _attachmentsCollection;

        public AttachmentRepository()
        {
            _dbContext = new LiteDatabase("workpermit.db");
            _attachmentsCollection = _dbContext.GetCollection<Attachment>("attachments");
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public Task<Attachment> Get(Guid id)
        {
            return Task.Run(() => _attachmentsCollection.FindById(id));
        }

        public Task Save(Attachment entity)
        {
            return Task.Run(() =>
            {
                if (_attachmentsCollection.FindById(entity.Id) != null)
                {
                    _attachmentsCollection.Update(entity.Id, entity);
                }
                else
                {
                    _attachmentsCollection.Insert(entity.Id, entity);
                }
            });

        }

        public Task Delete(Attachment entity)
        {
            return Task.Run(() => _attachmentsCollection.Delete(entity.Id));
        }

        public Task<IEnumerable<Attachment>> FindAll()
        {
            return Task.Run(() => _attachmentsCollection.FindAll());
        }
    }
}