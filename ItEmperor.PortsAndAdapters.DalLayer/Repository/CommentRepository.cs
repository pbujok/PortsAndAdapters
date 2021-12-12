using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ItEmperor.PortsAndAdapters.DalLayer.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        private BoardDbContext DbContext { get; }

        public CommentRepository(BoardDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<Comment> GetByIdAsync<TId>(TId id)
        {
            return await DbContext.Set<Comment>()
                                   .FindAsync(id);
        }
        
        public virtual async Task<IReadOnlyCollection<Comment>> GetManyAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await DbContext.Set<Comment>()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task AddAsync(Comment entity)
        {
            await DbContext.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<Comment> entities)
        {
            foreach (var item in entities)
            {
                await AddAsync(item);
            }
        }

        public async virtual Task RemoveAsync(Comment entity)
        {
            DbContext.Remove(entity);
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}