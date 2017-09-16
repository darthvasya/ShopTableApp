using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using dev.ShopTableApp.BusinessLogic.Pub.Contracts;
using dev.ShopTableApp.Common.Pub.DataTransferObjects;
using dev.ShopTableApp.Web.Models;

namespace dev.ShopTableApp.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShopsController : ApiController
    {
        private IShopService ShopService { get; }

        public ShopsController(IShopService shopService)
        {
            ShopService = shopService;
        }

        // GET api/<controller>
        public IEnumerable<ShopViewModel> Get()
        {
            try
            {
                return ShopService.GetShops().Select(g => new ShopViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Address = g.Address,
                    StartWorkTime = g.StartWorkTime,
                    EndWorkTime = g.EndWorkTime,
                    Items = g.Items.Select(p => new ItemViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description
                    }).ToList()
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(ShopViewModel shopModel)
        {
            try
            {
                var shopDto = new ShopDto
                {
                    Name = shopModel.Name,
                    Address = shopModel.Address,
                    StartWorkTime = shopModel.StartWorkTime,
                    EndWorkTime = shopModel.EndWorkTime,
                    Items = shopModel.Items.Select(g => new ItemDto
                    {
                        Name = g.Name,
                        Description = g.Description
                    }).ToList()
                };

                ShopService.AddShop(shopDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}