using ShoppingSQLiteDatabase.Models;
using ShoppingSQLiteDatabase.Service;
using System.Collections.ObjectModel;

namespace ShoppingSQLiteDatabase.Pages;

public partial class ProductPage : ContentPage
{
    private ShoppingDatabase _database;
    private CustomerProfile _currentCustomer;
    public ObservableCollection<ShoppingItems> Items { get; set; }

    public ProductPage()
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
        _currentCustomer = _database.GetCustomerById(1);
        Items = new ObservableCollection<ShoppingItems>(_database.GetAllShoppingItems());
    }

    private void AddShoppingItem_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var shoppingItem = (ShoppingItems)button.CommandParameter;

        _database.AddShoppingItemToCustomer(_currentCustomer.CustomerProfileId, shoppingItem.ItemId);
    }
}
