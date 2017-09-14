using System;
using System.Collections.Generic;

namespace dev.ShopTableApp.Web.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

        public virtual ICollection<ItemViewModel> Items { get; set; } = new HashSet<ItemViewModel>();
    }
}