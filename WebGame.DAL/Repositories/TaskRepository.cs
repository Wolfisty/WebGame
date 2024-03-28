using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using WebGame.DAL.Interfaces;
using WebGame.Domain.Entity;

namespace WebGame.DAL.Repositories
{
    public class TasksRepository : IBaseRepository<Tasks>
    {
        private readonly AppDbContext _db;

        public TasksRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(Tasks entity)
        {
            await _db.Tasks.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Tasks> GetAll()
        {
            return _db.Tasks;
        }

        public async Task Delete(Tasks entity)
        {
            _db.Tasks.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Tasks> Update(Tasks entity)
        {
            _db.Tasks.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
