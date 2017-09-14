using dev.ShopTableApp.DataAccess.EF.Pub;
using dev.ShopTableApp.DataAccess.Pub.Contracts;

namespace dev.ShopTableApp.DataAccess.Pub.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private ShopTableAppDbContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected ShopTableAppDbContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Get());

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}