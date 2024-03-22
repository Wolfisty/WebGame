using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.DAL.Interfaces;

namespace WebGame.DAL.Repositories
{
    public class TasksRepository : IBaseRepository<Books>
    {
        private readonly ApplicationDbContext _db;

        public TasksRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Books entity)
        {
            await _db.Tasks.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Books> GetAll()
        {
            return _db.Tasks;
        }

        public async Task Delete(Books entity)
        {
            _db.Tasks.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Tasks> Update(Books entity)
        {
            _db.Tasks.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
