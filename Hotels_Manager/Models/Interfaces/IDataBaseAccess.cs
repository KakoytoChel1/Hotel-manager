namespace Hotels_Manager.Models.Interfaces
{
    interface IDataBaseAccess
    {
        TEntity? Get<TEntity>(int id) where TEntity : class;
        IEnumerable<TEntity>? GetAll<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities)where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity)where TEntity : class;
        Task<TEntity?> GetAsync<TEntity>(int id) where TEntity : class;
        Task<IEnumerable<TEntity>>? GetAllAsync<TEntity>() where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;
        Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity)where TEntity : class;
    }
}
