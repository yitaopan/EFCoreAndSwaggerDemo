using EFCoreAndSwaggerDemo.Models.Entities;
using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAndSwaggerDemo.Data.RP
{
    public class RPContext : DbContext
    {
        public RPContext(DbContextOptions<RPContext> options) : base(options)
        {

        }

        public DbSet<AsyncOperationEntity> AsyncOperationEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsyncOperationEntity>().ToTable("AsyncOperationEntity");
        }

        public override int SaveChanges()
        {
            UpdateCreateTime();
            UpdateUpdateTime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateCreateTime();
            UpdateUpdateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateCreateTime()
        {
            var newEntities = ChangeTracker.Entries()
                .Where(entry => EntityState.Added.Equals(entry.State))
                .Select(entry => entry.Entity);

            foreach (BaseEntity entity in newEntities)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.LastUpdatedAt = DateTime.UtcNow;
            }
        }

        private void UpdateUpdateTime()
        {
            var updatedEntities = ChangeTracker.Entries()
                .Where(entry => EntityState.Modified.Equals(entry.State))
                .Select(entry => entry.Entity);

            foreach (BaseEntity entity in updatedEntities)
            {
                entity.LastUpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
