using ShoppingSQLiteDatabase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using SQLitePCL;




namespace ShoppingSQLiteDatabase.Service
{
    public class ShoppingDatabase
    {
        private SQLiteConnection _connection;

        public string GetDataBasePath() 
        {
            string fileName = "shoppingdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        
        }
        public ShoppingDatabase() 
        { 
        
            _connection = new SQLiteConnection(GetDataBasePath());

            _connection.CreateTable<CustomerProfile>();
            _connection.CreateTable<ShoppingItems>();

            SeedDatabase();

        }
        public void SeedDatabase()
        {
            if (_connection.Table<CustomerProfile>().Count() == 0)
            {
                CustomerProfile customerProfile = new CustomerProfile()
                {
                    CustomerName = "Luke",
                    CustomerSurname = "Padiachy",
                    CustomerEmail = "me@computer.co.za",
                    CustomerBio = "Life is Good"
                };
                _connection.Insert(customerProfile);
            }

            ShoppingItems shoppingItems = new ShoppingItems()
            {
                ItemName = "Headset",
                Price = "R 450.00",
                Quantity = 10,
                ImagePath = "https://m.media-amazon.com/images/I/61tl-Fi6-uL.jpg"

            };
            _connection.Insert(shoppingItems);
            
            shoppingItems = new ShoppingItems()
            {
                ItemName = "Studio Setup",
                Price = "R 7000.99",
                Quantity = 2,
                ImagePath = "https://media.takealot.com/covers_images/650c9814a20147f194d1f453dda1ded7/s-zoom.file"

            };
            _connection.Insert(shoppingItems);

            shoppingItems = new ShoppingItems()
            {
                ItemName = "Flexirolla",
                Price = "R 900.00",
                Quantity = 10,
                ImagePath = "https://miro.medium.com/v2/resize:fit:2000/1*aGoO5pKLUd67ecAJiQak_g.jpeg"

            };
            _connection.Insert(shoppingItems);
        }
        public CustomerProfile GetCustomerById(int Id)
        {
           CustomerProfile customerProfile = _connection.Table<CustomerProfile>().Where(x=>x.CustomerProfileId == Id).FirstOrDefault();
           return customerProfile;
        }

        public void UpdateCustomer(CustomerProfile customerProfile)
        {
            _connection.Update(customerProfile);
        }






    }
}
