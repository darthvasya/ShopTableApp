using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev.ShopTableApp.DataAccess.EF.Pub.Entity
{
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime StartWorkTime { get; set; }
        public DateTime EndWorkTime { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}