using Microsoft.EntityFrameworkCore;
using ShardingCore.Core.VirtualRoutes.TableRoutes.RouteTails.Abstractions;
using ShardingCore.Sharding;
using ShardingCore.Sharding.Abstractions;

namespace ShardingCoreTests.MultiField
{
    public class DefaultDbContext : AbstractShardingDbContext, IShardingTableDbContext
    {
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(order =>
            {
                order.ToTable("orders");
                order.HasKey(x => x.Id);
                order.Property(x => x.OrderNo).IsRequired().HasMaxLength(128).IsUnicode(false);
                order.Property(x => x.Name).IsRequired().HasMaxLength(128).IsUnicode(false);
            });
        }

        public IRouteTail RouteTail { get ; set; }
    }
}
