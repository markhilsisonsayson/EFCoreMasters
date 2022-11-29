﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
