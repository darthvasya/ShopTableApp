using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dev.ShopTableApp.BusinessLogic.Pub.Contracts;

namespace dev.ShopTableApp.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private IShopService ShopService { get; }

        public ValuesController(IShopService shopService)
        {
            ShopService = shopService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var shops = ShopService.GetShops();
            return new string[] { "value1" + shops.Count, "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
