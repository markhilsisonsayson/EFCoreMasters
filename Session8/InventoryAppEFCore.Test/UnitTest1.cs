using InventoryAppEFCore.DataLayer;
using Xunit;

namespace InventoryAppEFCore.Test
{
    public class UnitTest1
    {
       
        [Fact]
        public void Test_NetSalesOutPut()
        {   
            int quantity = 2;
            decimal list_price = 50;
            decimal discount = 20;
            decimal expectedoutput = 80;
            
            var actual= InventoryAppEfCoreContext.NetSales(quantity, list_price, discount);
            Assert.Equal(expectedoutput, actual);
        }

        [Fact]
        public void Test_NetSalesAllowsZeroDiscount() {
            int quantity = 2;
            decimal list_price = 50;
            decimal discount = 0;
            decimal expectedoutput = 100.00M;

            var actual = InventoryAppEfCoreContext.NetSales(quantity, list_price, discount);
            Assert.Equal(expectedoutput, actual);
        }
    }
}