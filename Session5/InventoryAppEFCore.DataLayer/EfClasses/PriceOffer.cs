using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class PriceOffer
    {
        private decimal _newPrice;
        public int PriceOfferId { get; set; }

        //public decimal NewPrice { get; set; }

        [BackingField(nameof(_newPrice))]
        public decimal NewPrice
        {
            get { return _newPrice; }
            set { _newPrice = value; }
        }

        public string PromotinalText { get; set; }

        //relationship---
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
    }
}
