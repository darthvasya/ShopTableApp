using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev.ShopTableApp.BusinessLogic.Pub.Contracts;
using dev.ShopTableApp.Common.Pub.DataTransferObjects;
using dev.ShopTableApp.DataAccess.Pub.Contracts;
using dev.ShopTableApp.DataAccess.Repository.Pub;

namespace dev.ShopTableApp.BusinessLogic.Pub.Implementations
{
    public class ItemService : IItemService
    {
        public ItemService(IItemRepository itemRepository, IShopRepository shopRepository, IUnitOfWork unitOfWork)
        {
            ItemRepository = itemRepository;
            ShopRepository = shopRepository;
            UnitOfWork = unitOfWork;
        }

        public IItemRepository ItemRepository { get; }
        public IShopRepository ShopRepository { get; }
        public IUnitOfWork UnitOfWork { get; }

        public List<ItemDto> GetItemsFromShop(int shopId)
        {
            return ItemRepository.GetMany(x => x.ShopId == shopId).Select(g => new ItemDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description
            }).ToList();
        }
    }
}
