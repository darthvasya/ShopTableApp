using dev.ShopTableApp.DataAccess.EF.Pub;
using dev.ShopTableApp.DataAccess.Pub.Contracts;

namespace dev.ShopTableApp.DataAccess.Pub.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ShopTableAppDbContext _dataContext;

        public ShopTableAppDbContext Get()
        {
            return _dataContext ?? (_dataContext = new ShopTableAppDbContext());
        }

        protected override void DisposeCore()
        {
            _dataContext?.Dispose();
        }
    }
}