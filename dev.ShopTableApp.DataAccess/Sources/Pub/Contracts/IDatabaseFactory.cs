using System;
using dev.ShopTableApp.DataAccess.EF.Pub;

namespace dev.ShopTableApp.DataAccess.Pub.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        ShopTableAppDbContext Get();
    }
}
