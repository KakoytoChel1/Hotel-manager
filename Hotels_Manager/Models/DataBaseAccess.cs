using Hotels_Manager.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotels_Manager.Models
{
    public class DataBaseAccess : IDataBaseAccess
    {
        protected readonly DbContext context;

        public DataBaseAccess(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adding an entity of type TEntity to the corresponding table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="Add(TEntity)"/>.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Adding a collection of entities of type TEntity to the corresponding table.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="AddRange(IEnumerable{TEntity})"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Getting an entity of TEntity type by primary key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? Get<TEntity>(int id) where TEntity : class
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Getting a collection of entities of type TEntity.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="GetAllAsync"/>.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>>? GetAllAsync<TEntity>() where TEntity : class
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="GetAsync(int)"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetAsync<TEntity>(int id) where TEntity : class
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Removing an entity of type TEntity from the corresponding table.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="Remove(TEntity)"/>.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Removing a collection of entities of type TEntity from the corresponding table.
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="RemoveRange(IEnumerable{TEntity})"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updating an entity of type TEntity with a new instance of the same type.
        /// </summary>
        /// <param name="entity"></param>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Asynchronous analogue of <see cref="Upfda"/>.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
