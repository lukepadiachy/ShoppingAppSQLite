using ShoppingSQLiteDatabase.Models;
using SQLite;




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
            _connection.CreateTable<ShoppingCart>();

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
            if (_connection.Table<ShoppingItems>().Count() == 0)
            {
                List<ShoppingItems> items = new List<ShoppingItems>()
                {
                    new ShoppingItems()
                    {
                        ItemName = "Headset",
                        Price = "R 450.00",
                        Quantity = 10,
                        ImagePath = "headset.jpg"
                    },

                    new ShoppingItems()
                    {
                        ItemName = "Studio Setup",
                        Price = "R 7000.99",
                        Quantity = 2,
                        ImagePath = "studio.jpg"
                    },

                    new ShoppingItems()
                    {
                        ItemName = "Flexirolla",
                        Price = "R 900.00",
                        Quantity = 10,
                        ImagePath = "flexirolla.jpg"
                    }
                };
                _connection.InsertAll(items);
            }
        }

        public CustomerProfile GetCustomerById(int Id)
        {
            CustomerProfile customerProfile = _connection.Table<CustomerProfile>().Where(x => x.CustomerProfileId == Id).FirstOrDefault();
            return customerProfile;
        }

        public void UpdateCustomer(CustomerProfile customerProfile)
        {
            _connection.Update(customerProfile);
        }

        public List<ShoppingItems> GetAllShoppingItems()
        {

            return _connection.Table<ShoppingItems>().ToList();

        }
        


    }
}