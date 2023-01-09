using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.Views
{
    public class VW_Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
