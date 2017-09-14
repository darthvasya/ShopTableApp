using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev.ShopTableApp.Common.Pub.DataTransferObjects;

namespace dev.ShopTableApp.BusinessLogic.Pub.Contracts
{
    public interface IItemService
    {
        List<ItemDto> GetItemsFromShop(int shopId);
    }
}
