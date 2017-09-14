using System;
using System.Collections.Generic;
using System.Linq;
using dev.ShopTableApp.BusinessLogic.Pub.Contracts;
using dev.ShopTableApp.Common.Pub.DataTransferObjects;
using dev.ShopTableApp.DataAccess.EF.Pub.Entity;
using dev.ShopTableApp.DataAccess.Pub.Contracts;
using dev.ShopTableApp.DataAccess.Repository.Pub;

namespace dev.ShopTableApp.BusinessLogic.Pub.Implementations
{
    public class ShopService : IShopService
    {
        public ShopService(IItemRepository itemRepository, IShopRepository shopRepository, IUnitOfWork unitOfWork)
        {
            ItemRepository = itemRepository;
            ShopRepository = shopRepository;
            UnitOfWork = unitOfWork;
        }

        public IItemRepository ItemRepository { get; }
        public IShopRepository ShopRepository { get; }
        public IUnitOfWork UnitOfWork { get; }

        public void AddShop(ShopDto shopDto)
        {
            if (shopDto == null) return;
            var shop = new Shop
            {
                Name = shopDto.Name,
                Address = shopDto.Address,
                StartWorkTime = shopDto.StartWorkTime,
                EndWorkTime = shopDto.EndWorkTime,
                Items = shopDto.Items.Select(g => new Item
                {
                    Name = g.Name,
                    Description = g.Description
                }).ToList()
            };

            //можно конечно использовать automapper, но объекты того не стоят

            ShopRepository.Add(shop);
            SaveChanges();
        }

        public void AddItem(ItemDto itemDto)
        {
            if (itemDto == null) return;
            var item = new Item()
            {
                Name = itemDto.Name,
                Description = itemDto.Description
            };

            ItemRepository.Add(item);
            SaveChanges();
        }

        public List<ShopDto> GetShops()
        {
            var shopsDto = ShopRepository.GetAll().Select(g => new ShopDto
            {
                Name = g.Name,
                Address = g.Address,
                StartWorkTime = g.StartWorkTime,
                EndWorkTime = g.EndWorkTime,
                Items = ItemRepository.GetMany(x => x.ShopId == g.Id).Select(p => new ItemDto()
                {
                    Name = p.Name,
                    Description = p.Description
                }).ToList()
            }).ToList();

            return shopsDto;
        }

        private void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}