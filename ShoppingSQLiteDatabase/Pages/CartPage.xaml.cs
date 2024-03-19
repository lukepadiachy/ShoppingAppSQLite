using ShoppingSQLiteDatabase.Service; 
using ShoppingSQLiteDatabase.Models;

namespace ShoppingSQLiteDatabase.Pages;

public partial class CartPage : ContentPage
{
    private ShoppingDatabase _database;

    public CartPage()
    {
        InitializeComponent();
        _database = new ShoppingDatabase();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCartItems();
    }

    private void LoadCartItems()
    {
        // Get the customer's shopping cart items from the database
        List<ShoppingCart> cartItems = _database.GetCustomerCartItems();


        // Set the items as the ListView's ItemSource
        cartListView.ItemsSource = cartItems;
    }
}
