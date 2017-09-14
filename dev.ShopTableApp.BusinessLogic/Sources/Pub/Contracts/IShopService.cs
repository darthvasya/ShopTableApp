using System.Collections.Generic;
using dev.ShopTableApp.Common.Pub.DataTransferObjects;

namespace dev.ShopTableApp.BusinessLogic.Pub.Contracts
{
    public interface IShopService
    {
        void AddShop(ShopDto shopDto);
        void AddItem(ItemDto itemDto);
        List<ShopDto> GetShops();
    }
}