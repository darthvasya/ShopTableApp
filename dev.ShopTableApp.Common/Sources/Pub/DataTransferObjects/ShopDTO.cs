using System;
using System.Collections.Generic;

namespace dev.ShopTableApp.Common.Pub.DataTransferObjects
{
    public class ShopDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

        public virtual ICollection<ItemDto> Items { get; set; } = new HashSet<ItemDto>();
    }
}