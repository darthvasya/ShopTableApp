using dev.ShopTableApp.DataAccess.EF.Pub;
using dev.ShopTableApp.DataAccess.EF.Pub.Entity;
using dev.ShopTableApp.DataAccess.Pub.Contracts;
using dev.ShopTableApp.DataAccess.Pub.Implementations;

namespace dev.ShopTableApp.DataAccess.Repository.Pub
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private ShopTableAppDbContext _dataContext;

        public ItemRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected new IDatabaseFactory DatabaseFactory { get; }

        protected new ShopTableAppDbContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());
    }

    public interface IItemRepository : IRepository<Item>
    {
    }
}