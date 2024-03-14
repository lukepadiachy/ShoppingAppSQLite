using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingSQLiteDatabase.Models
{
    public class ShoppingCart
    {
        [PrimaryKey,AutoIncrement]
        public int CartItemId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<CustomerProfile> CustomerProfile { get; set; }

        public ShoppingCart()
        {
            CustomerProfile = new List<CustomerProfile>();
        }
    }
}
