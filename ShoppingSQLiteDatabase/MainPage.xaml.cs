using ShoppingSQLiteDatabase.Models;
using ShoppingSQLiteDatabase.Service;
using System.Collections.ObjectModel;
using ShoppingSQLiteDatabase.Pages;




namespace ShoppingSQLiteDatabase
{
    public partial class MainPage : ContentPage
    {
        private ShoppingDatabase _database;
        private CustomerProfile _currentCustomer;
        

        public CustomerProfile CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;

                OnPropertyChanged();

            }
        }
        public MainPage()
        {
            InitializeComponent();

            _database = new ShoppingDatabase();

            BindingContext = this;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadData();
        }

        private void LoadData()
        {
            CustomerProfile customerProfile = _database.GetCustomerById(1);
            {

                CurrentCustomer = customerProfile;

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _database.UpdateCustomer(CurrentCustomer);
        }

        private async void PurchaseButton_Clicked_2(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new ProductPage());

            
        }
    }

}
